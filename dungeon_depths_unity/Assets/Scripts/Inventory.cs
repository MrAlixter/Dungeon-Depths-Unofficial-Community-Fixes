using Assets.Scripts;
using Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public enum ItemType { Useables, Potions, Armors, Weapons, Accessories, Keys }

[Savable]
public class Inventory
{
    private static Inventory _instance;
    public static Inventory instance { get { if(_instance == null) { _instance = new Inventory(); } return _instance; } }
    
    public Inventory()
    {
        types = new Dictionary<ItemType, List<Item>>();
        useables = new List<Item>();
        potions = new List<Item>();
        armors = new List<Item>();
        weapons = new List<Item>();
        accessories = new List<Item>();
        key_items = new List<Item>();

        types[ItemType.Useables] = useables;
        types[ItemType.Potions] = potions;
        types[ItemType.Armors] = armors;
        types[ItemType.Weapons] = weapons;
        types[ItemType.Accessories] = accessories;
        types[ItemType.Keys] = key_items;
    }

    public Dictionary<ItemType, List<Item>> types;
    [Savable]
    public List<Item> useables;
    [Savable]
    public List<Item> potions;
    [Savable]
    public List<Item> armors;
    [Savable]
    public List<Item> weapons;
    [Savable]
    public List<Item> accessories;
    [Savable]
    public List<Item> key_items;

    public void load()
    {
        Savable.load(this);
        types[ItemType.Useables] = useables;
        types[ItemType.Potions] = potions;
        types[ItemType.Armors] = armors;
        types[ItemType.Weapons] = weapons;
        types[ItemType.Accessories] = accessories;
        types[ItemType.Keys] = key_items;
    }

    public void load_default_values()
    {
        #region Potions
        potions.Add(HealthPotion.instance);

        foreach(Item potion in potions)
        {
            potion.count = 1;
        }
        #endregion

        #region Armors
        armors.Add(NoArmor.instance);
        armors.Add(SteelArmor.instance);
        armors.Add(GoldArmor.instance);
        armors.Add(ValkyrieArmor.instance);
        armors.Add(BrawlerCosplay.instance);
        armors.Add(BronzeArmor.instance);
        armors.Add(ChitinArmor.instance);
        armors.Add(WarriorsCuirass.instance);

        foreach(Armor armor in armors)
        {
            armor.count = 1;
        }
        armors[0].count = 0;

        armors.Sort();
        #endregion
    }

    public Armor get_armor_by_id(int id)
    {
        foreach (Armor armor in armors)
        {
            if (armor.id == id)
            { return armor; }
        }
        return null;
    }
}
