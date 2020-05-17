using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsModal : Modal, ItemHeader.ItemHeaderMaster, IEnsureVisible<ItemChoice>, ItemChoice.IItemChoiceMaster
{
    private static Player player;
    private static Inventory inventory;
    public GameObject item_choice_prefab;
    public GameObject item_option_prefab;

    private static GameObject headers;
    private static Dictionary<ItemType, ItemHeader> header_buttons;
    private static ItemHeader useables_header;
    private static ItemHeader potions_header;
    private static ItemHeader armors_header;
    private static ItemHeader weapons_header;
    private static ItemHeader accessories_header;
    private static ItemHeader keys_header;

    private ItemType current_header;

    private static GameObject scroll_section;
    private static Scrollbar scrollbar;
    private static GameObject item_list;
    private static RectTransform item_list_rt;
    private static HeightFitter height_fitter;

    private static IEquipmentMaster equipmentMaster;

    protected override void ModalStart()
    {
        player = Player.instance;
        inventory = Inventory.instance;

        ItemHeader.set_item_header_master(this);
        ItemChoice.set_ensure_visible_master(this);
        ItemChoice.set_item_choice_master(this);

        headers = panel.Find("Item Headers").gameObject;
        header_buttons = new Dictionary<ItemType, ItemHeader>();
        foreach(ItemHeader ih in headers.GetComponentsInChildren<ItemHeader>(true))
        {
            header_buttons[ih.type] = ih;
        }
        useables_header = header_buttons[ItemType.Useables];
        potions_header = header_buttons[ItemType.Potions];
        armors_header = header_buttons[ItemType.Armors];
        weapons_header = header_buttons[ItemType.Weapons];
        accessories_header = header_buttons[ItemType.Accessories];
        keys_header = header_buttons[ItemType.Keys];
        
        scroll_section = panel.Find("Scroll Section").gameObject;
        scrollbar = scroll_section.transform.Find("Scrollbar").GetComponent<Scrollbar>();
        item_list = scroll_section.transform.Find("Item List").gameObject;
        item_list_rt = item_list.GetComponent<RectTransform>();
        height_fitter = item_list.transform.Find("Height Fitter").GetComponent<HeightFitter>();

        equipmentMaster = Player.instance;
    }

    protected override void SetDefault()
    {
        //Called automatically from menu.open()
        SetDefault(useables_header.GetComponent<Selectable>());
    }

    protected private void SetDefault(Selectable selectable)
    {
        Player.event_system.SetSelectedGameObject(selectable.gameObject);
    }

    public override void open()
    {
        base.open();
        load_items();
    }

    public void load_items()
    {
        load_items(current_header);

        scrollbar.value = 1;
    }

    public void load_items(ItemType type)
    {
        foreach (Transform child in height_fitter.transform)
        {
            Destroy(child.gameObject);
            //Disable them because they won't be destroyed immediately.
            //and they'll mess with the resize because of that. but the
            // resize ignores inactive objects, so this make them not
            //factor into the repositioning and resizing of the height_fitter
            child.gameObject.SetActive(false); 
        }

        Selectable parent_left = header_buttons[type].navigation.selectOnLeft;
        Selectable parent_right = header_buttons[type].navigation.selectOnRight;

        ItemChoice previous = null;
        GameObject go = null;
        Navigation nav;
        bool first = true;
        if (header_buttons[type].selected)
        {
            foreach (Item item in inventory.types[type])
            {
                if (item.count > 0)
                {
                    //Eventually we may want to save these and just toggle though them. 
                    //For now, it's not an issue so I'm not going to bother
                    go = Instantiate(item_choice_prefab, height_fitter.transform);
                    ItemChoice ic = go.GetComponent<ItemChoice>();
                    ic.LoadItem(item);

                    if(first)
                    {
                        nav = header_buttons[type].navigation;
                        nav.selectOnDown = ic.selectable;
                        header_buttons[type].navigation = nav;

                        nav = ic.navigation;
                        nav.selectOnUp = header_buttons[type].selectable;
                        ic.navigation = nav;

                        first = false;
                    }

                    if(previous != null)
                    {
                        nav = ic.navigation;
                        nav.selectOnUp = previous.selectable;
                        ic.navigation = nav;

                        nav = previous.navigation;
                        nav.selectOnDown = ic.selectable;
                        previous.navigation = nav;
                    }

                    nav = ic.navigation;
                    nav.selectOnLeft = parent_left;
                    nav.selectOnRight = parent_right;
                    ic.navigation = nav;

                    previous = ic;
                }
            }
        }
        resize();
    }

    public void resize()
    {
       float h = height_fitter.update_children();
       item_list_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);
    }
    
    public void ensure_visible(ItemChoice me)
    {
        RectTransform total_rt = me.GetComponent<RectTransform>();
        RectTransform rt = me.transform.Find("Background").GetComponent<RectTransform>();

        float visible_size = scroll_section.GetComponent<RectTransform>().rect.height;
        RectTransform scroll_rt = item_list_rt;
        float scroll_offset = scroll_rt.anchoredPosition.y;
        //Rect r = rt.rect;

        float top_view_offset = total_rt.anchoredPosition.y;
        float anchor_relative = total_rt.anchoredPosition.y + scroll_offset;
        //Off the top, bring down
        if (anchor_relative > 0)
        {
            Vector2 pos = scroll_rt.anchoredPosition;
            pos.y -= anchor_relative;
            //Note: anchor_relative will be positive, so subtracting it will make the position closer to 0.
            //Where 0 is the scrollbar being at the top. Hence, this makes it scroll up so that the top is in view.
            scroll_rt.anchoredPosition = pos;
        }
        else
        {
            float distance_from_bottom = visible_size + anchor_relative - rt.rect.height;
            //Below the bottom
            if (distance_from_bottom < 0)
            {
                Vector2 pos = scroll_rt.anchoredPosition;
                pos.y -= distance_from_bottom;
                scroll_rt.anchoredPosition = pos;
            }
        }
    }

    public void ItemUsed(ItemChoice itemChoice)
    {
        itemChoice.associated_item.use();
        Selectable target = null;
        if (itemChoice.associated_item.count == 0)
        {
            target = header_buttons[current_header].selectable;
        }
        else
        {
            target = itemChoice.selectable;
        }
        SetDefault(target);
        target.Select();
    }

    public void ItemEquipped(ItemChoice itemChoice)
    {
        equipmentMaster.equip_armor(itemChoice.associated_item.id);
        itemChoice.selectable.Select();
    }

    public void ItemDiscarded(ItemChoice itemChoice)
    {
        itemChoice.associated_item.discard();
        Selectable target = null;
        if (itemChoice.associated_item.count == 0)
        {
            target = header_buttons[current_header].selectable;
        }
        else
        {
            target = itemChoice.selectable;
        }
        SetDefault(target);
        target.Select();
    }

    public void ItemCanceled()
    {
        header_buttons[current_header].button.Select();
    }

    public void selected(ItemType selected)
    {
        current_header = selected;
    }
    
}
