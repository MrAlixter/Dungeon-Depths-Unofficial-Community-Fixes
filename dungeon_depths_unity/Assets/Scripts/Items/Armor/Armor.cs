using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Armor : Item
{
    [JsonIgnore]
    protected static char sep = Path.DirectorySeparatorChar;
    [JsonIgnore]
    protected static string armor_path = "Player Images" + sep + "Equipment" + sep + "Armor";

    [JsonIgnore]
    public int attack_boost = 0;
    [JsonIgnore]
    public int defense_boost = 0;
    [JsonIgnore]
    public int health_boost = 0;
    [JsonIgnore]
    public int mana_boost = 0;
    [JsonIgnore]
    public int speed_boost = 0;
    [JsonIgnore]
    public int will_boost = 0;

    [JsonIgnore]
    public int slut_var_ind = -1;
    [JsonIgnore]
    public int anti_slut_var_ind = -1;

    [JsonIgnore]
    public int[] supported_sizes = new int[8];
    [JsonIgnore]
    public NegOneArr<Sprite> variants = new NegOneArr<Sprite>(9);
    [JsonIgnore]
    public bool compresses_breasts;
    
    public virtual void on_equip() { }
    public virtual void on_unequip() { }

    public Armor() : base()
    {

    }

    protected void fill_variants(string name)
    {
        foreach (int size in supported_sizes)
        {
            variants[size] = Resources.Load<Sprite>(armor_path+sep+name+sep+size);
        }
        //If 0 isn't explicitly supported
        if(!Array.Exists<int>(supported_sizes, e => e == 0))
        {
            //But -1 is
            if(Array.Exists<int>(supported_sizes, e => e == -1))
            {
                //then it also supports 0, with the image of -1
                variants[0] = Resources.Load<Sprite>(armor_path+sep+name+sep+"-1");
            }
        }
    }

    public bool supports_size(int size)
    {
        return variants[size] != null;
    }
}
