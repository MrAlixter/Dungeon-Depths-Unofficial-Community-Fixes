using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMenu : Menu
{
    private static EquipmentMenu _instance;
    public static EquipmentMenu instance { get { return _instance != null ? _instance : new EquipmentMenu(); } }

    public EquipmentMenu()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    private static GameObject left;
    private static UnityEngine.UI.Image armor_image;
    private static UnityEngine.UI.Text armor_name;
    private static UnityEngine.UI.Text weapon_name;
    private static UnityEngine.UI.Text accessory_name;

    private static GameObject right;
    private static UnityEngine.UI.Scrollbar scrollbar;
    private static GameObject equipment_options_container;
    private static HeightFitter equipment_options_container_hf;
    private static List<EquipmentChoice> equipment_options;

    public static GameObject equipment_choice_prefab;
    public static Inventory inventory;
    public static Player player;
    public static IEquipmentMaster equipment_master;


    public new void Awake()
    {
        base.Awake();

        //Because panel is set in Menu.Awake(), I cannot put these in a static constructor
        if(left == null) { left = panel.Find("Left Section").gameObject; }
        if(armor_image == null) { armor_image = left.transform.Find("Armor Slot").Find("Image").GetComponent<UnityEngine.UI.Image>();  }
        if(armor_name == null) { armor_name = left.transform.Find("Armor Slot").Find("Text").GetComponent<UnityEngine.UI.Text>();  }
        if(weapon_name == null) { weapon_name = left.transform.Find("Weapon Slot").Find("Text").GetComponent<UnityEngine.UI.Text>();  }
        if(accessory_name == null) { accessory_name = left.transform.Find("Accessory Slot").Find("Text").GetComponent<UnityEngine.UI.Text>();  }

        if (right == null) { right = panel.Find("Right Section").gameObject; }
        if (scrollbar == null) { scrollbar = right.transform.Find("Scrollbar").GetComponent<UnityEngine.UI.Scrollbar>(); }
        if (equipment_options_container == null) { equipment_options_container = right.transform.Find("Equipment Options").gameObject; }
        if (equipment_options_container_hf == null) { equipment_options_container_hf = equipment_options_container.GetComponent<HeightFitter>(); }
        if (equipment_options == null) { equipment_options = new List<EquipmentChoice>(); }

        //I'd like to have this a static constructor, but .Load() is not allowed in constructors
        if(equipment_choice_prefab == null) { equipment_choice_prefab = (GameObject)Resources.Load("Equipment Option Button"); }
        if(inventory == null) { inventory = Inventory.instance; }
        if(player == null) { player = Player.instance; }
        if(equipment_master == null) { equipment_master = Master.instance; }
        
    }

    public void set_scrollbar_value(int value)
    {
        scrollbar.value = value;
    }

    public void load_armor_choices()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in equipment_options_container.transform)
        {
            children.Add(child.gameObject);
            //Because both unparenting and deleting the child immediately increment
            //the iterator, despite the children not disappearing until the end of the
            //frame, I need to create my only list and destroy them on my own. 
        }
        foreach(GameObject child in children)
        {
            child.transform.SetParent(null);
            Destroy(child);
        }
        equipment_options.Clear();


        GameObject choice;
        RectTransform rt;
        EquipmentChoice ec;
        foreach(Armor armor in inventory.armors)
        {
            choice = Instantiate(equipment_choice_prefab, equipment_options_container.gameObject.transform);
            rt = choice.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);
            rt.anchoredPosition = new Vector2(0, 0);

            ec = new EquipmentChoice(choice);
            ec.name.text = armor.name;
            ec.description.text = armor.description;
            ec.image.sprite = armor.variants[player.breast_size];
            //If there isn't a supported image of that size, show the next closest
            if(ec.image.sprite == null)
            {
                //Start by checking up
                for (int i = player.breast_size; i <= 7; i++)
                {
                    Sprite s = armor.variants[i];
                    if (s != null)
                    {
                        ec.image.sprite = s;
                        break;
                    }
                }
                if(ec.image.sprite == null)
                {
                    //Then check down
                    for (int i = player.breast_size; i >= 0; i--)
                    {
                        Sprite s = armor.variants[i];
                        if (s != null)
                        {
                            ec.image.sprite = s;
                            break;
                        }
                    }
                    if (ec.image.sprite == null)
                    {
                        //SHOULD NEVER REACH HERE
                        //If it does, then there are no 
                        //supported images for the armor.
                        Debug.LogError($"No variants for {armor.actual_name} found!");
                    }
                }
            }

            string stat_txt = "";
            //Note the sign() and Math.Abs()
            //In short, I'm forcing the sign to always show
            //Also note the non-breaking space ("\u00A0")
            if (armor.attack_boost != 0) { stat_txt += $"\nATK:\u00A0{sign(armor.attack_boost)}{Math.Abs(armor.attack_boost)}"; }
            if (armor.defense_boost != 0) { stat_txt += $"\nDEF:\u00A0{sign(armor.defense_boost)}{Math.Abs(armor.defense_boost)}"; }
            if (armor.health_boost != 0) { stat_txt += $"\n\u00A0HP:\u00A0{sign(armor.health_boost)}{Math.Abs(armor.health_boost)}"; }
            if (armor.mana_boost != 0) { stat_txt += $"\nMAN:\u00A0{sign(armor.mana_boost)}{Math.Abs(armor.mana_boost)}"; }
            if (armor.speed_boost != 0) { stat_txt += $"\nSPD:\u00A0{sign(armor.speed_boost)}{Math.Abs(armor.speed_boost)}"; }
            if (armor.will_boost != 0) { stat_txt += $"\nWIL:\u00A0{sign(armor.will_boost)}{Math.Abs(armor.will_boost)}"; }

            ec.stats.text = stat_txt;

            ec.info.id = armor.id;

            for(int i = -1; i <= 7; i++)
            {
                UIRectangle curr = ec.sizes[i+1];
                if(armor.variants[i] == null)
                {
                    //Incompatible at current size
                    if(player.breast_size == i)
                    {
                        curr.color = Color.red;
                    }
                    //Could not support size
                    else
                    {
                        curr.color = Color.grey;
                    }
                }
                else
                {
                    //Fits current size
                    if(player.breast_size == i)
                    {
                        curr.color = Color.green;
                    }
                    //Would support size
                    else
                    {
                        curr.color = Color.white;
                    }
                }
            }

            ec.button.onClick.AddListener(() => equipment_master.set_armor(armor.id));

            choice.SetActive(true);
        }

        equipment_options_container_hf.update_children();
        scrollbar.value = 1;
    }

    public void load_current_equipment()
    {
        Armor a = inventory.get_armor_by_id(player.equipped_armor_id);
        armor_image.sprite = a.variants[player.breast_size];
        armor_image.color = Color.white;
        armor_name.text = a.actual_name;
    }

    private string sign(int num)
    {
        if(num > 0) { return "+"; }
        else if (num < 0) { return "-"; }
        return "\u00A0"; //Non-breaking space, to preserve formatting
    }
}