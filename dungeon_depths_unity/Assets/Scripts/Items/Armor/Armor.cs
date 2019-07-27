using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    protected static string armor_path = "Player Images/Equipment/Armor";

    public int attack_boost = 0;
    public int defense_boost = 0;
    public int health_boost = 0;
    public int mana_boost = 0;
    public int speed_boost = 0;
    public int will_boost = 0;

    public int slut_var_ind = -1;
    public int anti_slut_var_ind = -1;

    public int[] supported_sizes = new int[8];
    public NegOneArr<Sprite> variants = new NegOneArr<Sprite>(9);
    public bool compresses_breasts;
    
    public virtual void on_equip() { }
    public virtual void on_unequip() { }

    protected void fill_variants(string name)
    {
        foreach (int size in supported_sizes)
        {
            variants[size] = Resources.Load<Sprite>($"{armor_path}/{name}/{size}");
        }
        //If 0 isn't explicitly supported
        if(!Array.Exists<int>(supported_sizes, e => e == 0))
        {
            //But -1 is
            if(Array.Exists<int>(supported_sizes, e => e == -1))
            {
                //then it also supports 0, with the image of -1
                variants[0] = Resources.Load<Sprite>($"{armor_path}/{name}/-1");
            }
        }
    }

    public bool supports_size(int size)
    {
        return variants[size] != null;
    }
}
