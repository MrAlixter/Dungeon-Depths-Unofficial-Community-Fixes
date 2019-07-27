using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
    private static Inventory _instance;
    public static Inventory instance { get { return _instance != null ? _instance : new Inventory(); } }

    public List<Item> useables;
    public List<Item> potions;
    public List<Armor> armors;
    public List<Item> weapons;
    public List<Item> accessories;
    public List<Item> miscs;

    public Inventory()
    {
        if (_instance != null && _instance != this) { Destroy(this); }
        else { _instance = this; }

        #region Armors
        armors = new List<Armor>();

        armors.Add(new SteelArmor());
        armors.Add(new GoldArmor());
        armors.Add(new ValkyrieArmor());
        armors.Add(new BrawlerCosplay());
        armors.Add(new BronzeArmor());
        armors.Add(new ChitinArmor());
        armors.Add(new WarriorsCuirass());

        foreach (Armor armor in armors)
        {
            armor.count = 1;
        }

        armors.Sort();
        #endregion

        #region Potions
        potions = new List<Item>();

        potions.Add(new HealthPotion());

        foreach(Item potion in potions)
        {
            potion.count = 1;
        }
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
