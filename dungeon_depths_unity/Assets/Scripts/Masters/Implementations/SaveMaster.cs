using Scripts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections;
using Assets.Scripts;

public class SaveMaster : ISaveMaster
{
    private static SaveMaster _instance;
    public static SaveMaster instance { get { if(_instance == null) { _instance = new SaveMaster(); } return _instance; } }

    public SaveMaster()
    {
        if(!Directory.Exists(save_folder))
        {
            Directory.CreateDirectory(save_folder);
        }

        //if(save_data == null)
        //{
        //    load();
        //}
    }

    private static string save_folder = Application.dataPath + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "Saves" + Path.DirectorySeparatorChar;

    private static Dictionary<string, Dictionary<string, object>> save_data;

    public static Dictionary<string, object> my_save_data(object obj)
    {
        return my_save_data(obj.GetType().FullName);
    }

    public static Dictionary<string, object> my_save_data(string full_class_name)
    {
        return save_data[full_class_name];
    }

    public void save(int save_number)
    {
        Dictionary<string, Dictionary<string, (string, object)>> toSave = new Dictionary<string, Dictionary<string, (string, object)>>();
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach(Assembly assembly in assemblies)
        {
            foreach(Type type in assembly.GetTypes())
            {
                object[] attrs = type.GetCustomAttributes(typeof(Savable), true);
                if(attrs != null && attrs.Length > 0)
                {
                    object instance = type.GetProperty("instance", BindingFlags.Static | BindingFlags.Public).GetGetMethod().Invoke(null, null);

                    List<PropertyInfo> propertiesToSave = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Where(p => Attribute.IsDefined(p, typeof(Savable))).ToList();
                    List<(string, string, object)> valuesToSave = propertiesToSave.Select(pi => (pi.PropertyType.FullName, pi.Name, pi.GetValue(instance))).ToList(); 
                    List<FieldInfo> fieldsToSave = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Where(f => Attribute.IsDefined(f, typeof(Savable))).ToList();
                    valuesToSave.AddRange(fieldsToSave.Select(fi => (fi.FieldType.FullName, fi.Name, fi.GetValue(instance))).ToList());


                    Dictionary<string, (string, object)> dataFromClass = new Dictionary<string, (string, object)>();
                    foreach((string, string, object) valueData in valuesToSave)
                    {
                        string type_name = valueData.Item1;
                        string value_name = valueData.Item2;
                        object value = valueData.Item3;
                        
                        dataFromClass.Add(value_name, (type_name, value));
                    }
                    toSave.Add(type.FullName, dataFromClass);
                }
            }
        }
        
        string save = JsonConvert.SerializeObject(toSave);
        string fileLocation = save_folder + $"{save_number}.save";
        File.WriteAllText(fileLocation, save); //Overrides if it exists
    }

    public void load(int save_number)
    {
        string fileLocation = save_folder + $"{save_number}.save";
        string save = File.ReadAllText(fileLocation);

        Dictionary<string, Dictionary<string, (string, object)>> save_data_raw = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, (string, object)>>>(save);

        Dictionary<string, Dictionary<string, object>> save_data_fixed = new Dictionary<string, Dictionary<string, object>>();
        foreach(KeyValuePair<string, Dictionary<string, (string, object)>> class_data in save_data_raw)
        {
            Dictionary<string, object> new_class_data = new Dictionary<string, object>();
            foreach(KeyValuePair<string, (string, object)> value_data in class_data.Value)
            {
                Type new_value_type = Type.GetType(value_data.Value.Item1);
                object new_value_data = value_data.Value.Item2;
                if(new_value_type == null) //Failed to find
                {
                    string new_value_type_str = value_data.Value.Item1;
                    if(new_value_type_str.Contains("."))
                    {
                        string[] new_value_type_strs = new_value_type_str.Split('.');
                        string assembly = new_value_type_strs[0];
                        for(int i = 1; i < new_value_type_strs.Length - 1; i++)
                        {
                            assembly += "." + new_value_type_strs[i];
                        }
                        new_value_type = Type.GetType($"{new_value_type_str}, {assembly}", true);
                    }
                }
                try
                {
                    new_value_data = Convert.ChangeType(new_value_data, new_value_type);
                }
                catch(Exception e)
                {
                    if(e is InvalidCastException)
                    {
                        try
                        {
                            bool handled = false;
                            if(new_value_type.IsGenericType)
                            {
                                Type generic_type1 = new_value_type.GetGenericArguments()[0];
                                if(generic_type1.IsGenericType)
                                {
                                    if(generic_type1.GetGenericTypeDefinition() == typeof(MoveMap<>))
                                    {
                                        new_value_data = ((JArray)new_value_data).ToObject(new_value_type);
                                        IList data = new_value_data as IList;
                                        int count = data.Count;
                                        for(int i = 0; i < count; i++)
                                        {
                                            object thisMoveMap = data[i];
                                            FieldInfo fi = generic_type1.GetField("map", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                                            object map = fi.GetValue(thisMoveMap);
                                            Type mapType = map.GetType();
                                            MethodInfo lengthInfo = mapType.GetMethod("GetLength");
                                            int w = (int)lengthInfo.Invoke(map, new object[] { 1 });
                                            int h = (int)lengthInfo.Invoke(map, new object[] { 0 });
                                            //int h;

                                            PropertyInfo pi = generic_type1.GetProperty("width", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                                            pi.SetValue(thisMoveMap, w);
                                            pi = generic_type1.GetProperty("height", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                                            pi.SetValue(thisMoveMap, h);
                                        }
                                        handled = true;
                                    }
                                }
                                else if(typeof(Ability).IsAssignableFrom(generic_type1))
                                {
                                    PropertyInfo pi = typeof(Ability).GetProperty("type", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                                    Assembly assembly = typeof(Ability).Assembly;
                                    JArray data = new_value_data as JArray;
                                    List<Ability> converted = new List<Ability>();
                                    foreach(JToken ability in data)
                                    {
                                        JEnumerable<JProperty> properties = ability.Children<JProperty>();
                                        JProperty type_property = properties.FirstOrDefault(x => x.Name == "type");
                                        JToken type_token = type_property.Value;
                                        string type_name = type_token.ToObject<string>();
                                        Ability inst = (Ability)assembly.CreateInstance(type_name);
                                        converted.Add(inst);
                                        //object inst = Activator.CreateInstance(assembly, split_type_name[split_type_name.Length-1]);
                                    }

                                    //I don't like having to rely on the name of the field for this
                                    //However, empty lists have no way of being differentiating between a Spell list and an Ability list
                                    //Perhaps the data list should just be the parent class of Ability, not the derived classes
                                    if(value_data.Key == "spells")
                                    {
                                        new_value_data = converted.Cast<Spell>().ToList();
                                    }
                                    else if(value_data.Key == "specials")
                                    {
                                        new_value_data = converted.Cast<Special>().ToList();
                                    }
                                    handled = true;
                                }
                                else if(typeof(Item).IsAssignableFrom(generic_type1))
                                {
                                    PropertyInfo pi = typeof(Ability).GetProperty("type", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                                    Assembly assembly = typeof(Ability).Assembly;
                                    JArray data = new_value_data as JArray;
                                    List<Item> converted = new List<Item>();
                                    foreach(JToken item in data)
                                    {
                                        JEnumerable<JProperty> properties = item.Children<JProperty>();
                                        JProperty type_property = properties.FirstOrDefault(x => x.Name == "type");
                                        JToken type_token = type_property.Value;
                                        string type_name = type_token.ToObject<string>();
                                        Item inst = (Item)assembly.CreateInstance(type_name);
                                        JProperty count_proerty = properties.FirstOrDefault(x => x.Name == "count");
                                        JToken count_token = count_proerty.Value;
                                        int count = count_token.ToObject<int>();
                                        inst.count = count;
                                        converted.Add(inst);
                                        //object inst = Activator.CreateInstance(assembly, split_type_name[split_type_name.Length-1]);
                                    }
                                    new_value_data = converted;
                                    handled = true;
                                }
                            }

                            if(!handled)
                            {
                                new_value_data = ((JArray)new_value_data).ToObject(new_value_type);
                            }
                        }
                        catch(Exception e2)
                        {
                            if(e2 is InvalidCastException)
                            {
                                if(new_value_type == typeof(Vector2Int))
                                {
                                    JObject data = new_value_data as JObject;
                                    new_value_data = new Vector2Int(data.GetValue("x").ToObject<int>(), data.GetValue("y").ToObject<int>());
                                }
                                else if(new_value_type == typeof(SerializableColor))
                                {
                                    JObject data = new_value_data as JObject;
                                    float[] colorStore = data.GetValue("colorStore").ToObject<float[]>();
                                    new_value_data = (SerializableColor)new Color(colorStore[0], colorStore[1], colorStore[2], colorStore[3]);
                                }
                                else if(new_value_type == typeof(Player.SEX))
                                {
                                    new_value_data = Enum.Parse(typeof(Player.SEX), new_value_data.ToString(), true);
                                }
                                //Add specific handles for incorrectly handled types here
                                else
                                {
                                    Debug.LogError($"UNHANDLED TYPE {new_value_type} IN LOAD. VALUE NAMED {value_data.Key} IN CLASS {class_data.Key}");
                                }
                            }
                        }
                    }
                }

                new_class_data.Add(value_data.Key, new_value_data);
            }
            save_data_fixed.Add(class_data.Key, new_class_data);
        }
        SaveMaster.save_data = save_data_fixed;
    }
}
