using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentModal : Modal, IEnsureVisible<EquipmentChoice>, IEquipmentModal
{
    private static GameObject left;
    private static Button armor_slot;
    private static Button weapon_slot;
    private static Button accessory_slot;
    private static Image armor_image;
    private static TextMeshProUGUI armor_name;
    private static TextMeshProUGUI weapon_name;
    private static TextMeshProUGUI accessory_name;

    private static GameObject right;
    private static Scrollbar scrollbar;
    private static GameObject equipment_options_container;
    private static HeightFitter equipment_options_container_hf;
    private static List<EquipmentChoice> equipment_options;

    private GameObject equipment_choice_prefab;
    private static Inventory inventory;
    private static Player player;
    private static IEquipmentMaster equipment_master;


    protected override void ModalStart()
    {
        //Because panel is set in Menu.Awake(), I cannot put these in a static constructor
        if(left == null) { left = panel.Find("Left Section").gameObject; }
        if(armor_slot == null) { armor_slot = left.transform.Find("Armor Slot").GetComponent<Button>(); }
        if(weapon_slot == null) { weapon_slot = left.transform.Find("Weapon Slot").GetComponent<Button>(); }
        if(accessory_slot == null) { accessory_slot = left.transform.Find("Weapon Slot").GetComponent<Button>(); }
        if(armor_image == null) { armor_image = armor_slot.transform.Find("Image").GetComponent<Image>();  }
        if(armor_name == null) { armor_name = armor_slot.transform.Find("Text").GetComponent<TextMeshProUGUI>();  }
        if(weapon_name == null) { weapon_name = weapon_slot.transform.Find("Text").GetComponent<TextMeshProUGUI>();  }
        if(accessory_name == null) { accessory_name = accessory_slot.transform.Find("Text").GetComponent<TextMeshProUGUI>();  }

        if(right == null) { right = panel.Find("Right Section").gameObject; }
        if(scrollbar == null) { scrollbar = right.transform.Find("Scrollbar").GetComponent<UnityEngine.UI.Scrollbar>(); }
        if(equipment_options_container == null) { equipment_options_container = right.transform.Find("Equipment Options").gameObject; }
        if(equipment_options_container_hf == null) { equipment_options_container_hf = equipment_options_container.GetComponent<HeightFitter>(); }
        if(equipment_options == null) { equipment_options = new List<EquipmentChoice>(); }

        //I'd like to have this a static constructor, but .Load() is not allowed in constructors
        if(equipment_choice_prefab == null) { equipment_choice_prefab = Resources.Load<GameObject>("Prefabs"+SEP+"UI"+SEP+"Elements"+SEP+"Equipment Option Button"); }
        if(inventory == null) { inventory = Inventory.instance; }
        if(player == null) { player = Player.instance; }
        if(equipment_master == null) { equipment_master = Player.instance; }

        EquipmentChoice.ensure_visible_master = this;
    }

    protected override void SetDefault()
    {
        Player.event_system.SetSelectedGameObject(armor_slot.gameObject);
    }

    public override void open()
    {
        base.open();
        load_current_equipment();
        load_armor_choices();
    }

    public void set_scrollbar_value(int value)
    {
        scrollbar.value = value;
    }

    public void unload_choices()
    {
        foreach (Transform child in equipment_options_container.transform)
        {
            Destroy(child.gameObject);
        }
        equipment_options.Clear();
    }

    public void load_armor_choices()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in equipment_options_container.transform)
        {
            children.Add(child.gameObject);
            //Because both unparenting and deleting the child immediately increment
            //the iterator, despite the children not disappearing until the end of the
            //frame, I need to create my own list and destroy them on my own. 
        }
        foreach(GameObject child in children)
        {
            child.transform.SetParent(null);
            Destroy(child);
        }
        equipment_options.Clear();

        Navigation temp;
        EquipmentChoice previous = null;

        GameObject choice;
        RectTransform rt;
        EquipmentChoice ec;
        foreach(Armor armor in inventory.armors)
        {
            if(armor.count <= 0) { continue; }

            choice = Instantiate(equipment_choice_prefab, equipment_options_container.gameObject.transform);
            rt = choice.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);
            rt.anchoredPosition = new Vector2(0, 0);

            ec = choice.GetComponent<EquipmentChoice>();
            equipment_options.Add(ec);
            ec.Awake();
            ec.nameText.text = armor.name;
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

            ec.id = armor.id;

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

            ec.button.onClick.AddListener(() =>
                { equipment_master.equip_armor(armor.id, true); });
            
            temp = ec.button.navigation;
            temp.selectOnLeft = armor_slot.GetComponent<Selectable>();
            if(previous != null)
            {
                temp.selectOnUp = previous.GetComponent<Selectable>();
                Navigation previousNav = previous.button.navigation;
                previousNav.selectOnDown = ec.GetComponent<Selectable>();
                previous.button.navigation = previousNav;
            }
            previous = ec;
            ec.button.navigation = temp;

            choice.SetActive(true);
        }

        equipment_options_container_hf.update_children();
        scrollbar.value = 1;
        
        //TODO Handle zero choices
        Selectable firstChoice = equipment_options_container.transform.GetComponentsInChildren<Transform>()[1].gameObject.GetComponent<Selectable>();

        temp = armor_slot.navigation;
        temp.selectOnRight = firstChoice;
        armor_slot.navigation = temp;

        temp = weapon_slot.navigation;
        temp.selectOnRight = firstChoice;
        weapon_slot.navigation = temp;

        temp = accessory_slot.navigation;
        temp.selectOnRight = firstChoice;
        accessory_slot.navigation = temp;
    }

    public void load_current_equipment()
    {
        equip_armor(player.equipped_armor_id);
        equip_weapon(null); //TODO
        equip_accessory(null); //TODO
    }

    public void ensure_visible(EquipmentChoice ec)
    {
        float visible_size = right.GetComponent<RectTransform>().rect.height;
        RectTransform scroll_rt = equipment_options_container.GetComponent<RectTransform>();
        float scroll_offset = scroll_rt.anchoredPosition.y;
        RectTransform rt = ec.GetComponent<RectTransform>();
        Rect r = rt.rect;

        float top_view_offset = rt.anchoredPosition.y;
        bool top_in_view = top_view_offset > 0 && top_view_offset < visible_size;
        bool bottom_in_view = top_view_offset + r.height > 0 && top_view_offset + r.height < visible_size;

        float anchor_relative = rt.anchoredPosition.y + scroll_offset;
        //Off the top, bring down
        if(anchor_relative > 0)
        {
            Vector2 pos = scroll_rt.anchoredPosition;
            pos.y -= anchor_relative; 
            //Note: anchor_relative will be positive, so subtracting it will make the position closer to 0.
            //Where 0 is the scrollbar being at the top. Hence, this makes it scroll up so that the top is in view.
            scroll_rt.anchoredPosition = pos;
        }
        else
        {
            float distance_from_bottom = visible_size + anchor_relative - r.height;
            //Below the bottom
            if(distance_from_bottom < 0)
            {
                Vector2 pos = scroll_rt.anchoredPosition;
                pos.y -= distance_from_bottom;
                scroll_rt.anchoredPosition = pos;
            }
        }
    }

    private string sign(int num)
    {
        if(num > 0) { return "+"; }
        else if (num < 0) { return "-"; }
        return "\u00A0"; //Non-breaking space, to preserve formatting
    }

    public void equip_armor(int armor_id)
    {
        equip_armor(inventory.get_armor_by_id(player.equipped_armor_id));
    }
    public void equip_weapon(int item_id)
    {
        //TODO   
    }
    public void equip_accessory(int item_id)
    {
        //TODO   
    }
    public void equip_armor(Armor armor)
    {
        armor_image.sprite = armor.variants[player.breast_size];
        armor_image.color = Color.white;
        armor_name.text = armor.actual_name;
    }
    public void equip_weapon(Item item)
    {
        //TODO   
    }
    public void equip_accessory(Item item)
    {
        //TODO
    }

    
}