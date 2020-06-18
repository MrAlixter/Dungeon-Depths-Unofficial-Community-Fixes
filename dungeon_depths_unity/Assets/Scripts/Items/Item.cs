using Newtonsoft.Json;
using System;

public abstract class Item : IComparable
{
    protected static IMessageMaster message_master;

    public string type { get; private set; }

    [JsonIgnore]
    public string name { get; protected set; } = "DEFAULT_NAME";
    [JsonIgnore]
    public string actual_name { get { return name; } }
    [JsonIgnore]
    public string description { get; protected set; } = "DEFAULT_DESCRIPTION";

    [JsonIgnore]
    public bool is_usable { get; protected set; } = false;


    public int count { get; set; } = -1;
    [JsonIgnore]
    public int value { get; set; } = -1;
    [JsonIgnore]
    public int tier { get; set; } = -1;
    [JsonIgnore]
    public int id { get; set; } = -1;
    [JsonIgnore]
    public bool is_monster_drop { get; set; } = false;

    [JsonIgnore]
    public int sale_limit { get; set; } = 999;
    //public delegate void on_sell();
    //public delegate void on_buy();

    public Item()
    {
        if(message_master == null)
        {
            message_master = Master.get_master<IMessageMaster>();
        }
        type = GetType().FullName;
    }

    public int CompareTo(object obj)
    {
        //Because Item is abstract, every item 
        //using ComapreTo should be a subclass of it.
        //If it isn't, we can't sort them.
        if(!obj.GetType().IsSubclassOf(typeof(Item)))
            { return 0; }
        
        return name.CompareTo((obj as Item).name);
    }

    public virtual void use()
    {
        if(!is_usable) { return; }
        message_master.display_message($"You use the {name}");
    }
    protected void add_one() { count++; }
    protected virtual void add(int i) { count += i; }
    public virtual void discard()
    {
        message_master.display_message($"You drop the {name}");
        count--;
    }
    public virtual void remove()
    {
        message_master.display_message($"The {name} fades into non-existance");
        count--;
    }
    public void examine() { message_master.display_message(description); }
}
