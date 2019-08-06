using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum ItemType { Useables, Potions, Armors, Weapons, Accessories, Keys }

public class Inventory : ScriptableObject
{
    private static Inventory _instance;
    public static Inventory instance { get { return _instance != null ? _instance : CreateInstance<Inventory>(); } }

    public Dictionary<ItemType, List<Item>> types;
    public List<Item> useables;
    public List<Item> potions;
    public List<Item> armors;
    public List<Item> weapons;
    public List<Item> accessories;
    public List<Item> keys;

    public void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(this); return; }
        else { _instance = this; }

        types = new Dictionary<ItemType, List<Item>>();

        #region Useables
        useables = new List<Item>();
        #endregion

        #region Potions
        potions = new List<Item>();

        potions.Add(CreateInstance<HealthPotion>());

        foreach (Item potion in potions)
        {
            potion.count = 1;
        }
        #endregion

        #region Armors
        armors = new List<Item>();

        armors.Add(CreateInstance<SteelArmor>());
        armors.Add(CreateInstance<GoldArmor>());
        armors.Add(CreateInstance<ValkyrieArmor>());
        armors.Add(CreateInstance<BrawlerCosplay>());
        armors.Add(CreateInstance<BronzeArmor>());
        armors.Add(CreateInstance<ChitinArmor>());
        armors.Add(CreateInstance<WarriorsCuirass>());

        foreach (Armor armor in armors)
        {
            armor.count = 1;
        }

        armors.Sort();
        #endregion
        
        #region Weapons
        weapons = new List<Item>();
        #endregion

        #region Accessories
        accessories = new List<Item>();
        #endregion

        #region Keys
        keys = new List<Item>();
        #endregion

        types[ItemType.Useables] = useables;
        types[ItemType.Potions] = potions;
        types[ItemType.Armors] = armors;
        types[ItemType.Weapons] = weapons;
        types[ItemType.Accessories] = accessories;
        types[ItemType.Keys] = keys;
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
