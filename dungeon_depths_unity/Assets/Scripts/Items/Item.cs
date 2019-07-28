using System;
using UnityEngine;

public abstract class Item : ScriptableObject, IComparable
{
    protected static IMessageMaster messageMaster;
    static Item()
    {
        messageMaster = Master.instance;
    }

    //Note: I am overriding the ScriptableObject.name
    //However, since it's never put in the heirarchy and 
    //I'm never searching by name, I don't care.
    //And I need to inherit ScriptableObject because I can't call
    //Object.Destroy() otherwise, which would mean that I 
    //wouldn't be able to make Items into singletons
    public new string name { get; protected set; } = "DEFAULT_NAME";
    public string actual_name { get { return name; } }
    public string description { get; protected set; } = "DEFAULT_DESCRIPTION";

    public bool is_usable { get; protected set; } = false;

    public int count { get; set; } = -1;
    public int value { get; set; } = -1;
    public int tier { get; set; } = -1;
    public int id { get; set; } = -1;
    public bool is_monster_drop { get; set; } = false;

    public int sale_limit { get; set; } = 999;
    //public delegate void on_sell();
    //public delegate void on_buy();

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
        messageMaster.display_message($"You use the {name}");
    }
    protected void add_one() { count++; }
    protected virtual void add(int i) { count += i; }
    public virtual void discard()
    {
        messageMaster.display_message($"You drop the {name}");
        count--;
    }
    public virtual void remove()
    {
        messageMaster.display_message($"The {name} fades into non-existance");
        count--;
    }
    public void examine() { messageMaster.display_message(description); }
}
