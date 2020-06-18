using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Scripts
{
    public class Savable : System.Attribute
    {
        public static void load(object me)
        {
            Type myType = me.GetType();
            Dictionary<string, object> my_save_data = SaveMaster.my_save_data(me);
            foreach(KeyValuePair<string, object> saved_value in my_save_data)
            {
                string property_name = saved_value.Key;
                object value = saved_value.Value;

                //Type value_type = Type.GetType(property_type);
                PropertyInfo pi = myType.GetProperty(property_name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if(pi != null)
                {
                    pi.SetValue(me, value);
                }

                FieldInfo fi = myType.GetField(property_name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if(fi != null)
                {
                    fi.SetValue(me, value);
                }
                //Debug.Log($"Done loading {myType.FullName}.{property_name}");
            }
            //Debug.Log($"Done loading all values for {myType.FullName}");
        }
    }

    public interface ISaveMaster
    {
        void save(int save_number);
        void load(int save_number);
    }
}
