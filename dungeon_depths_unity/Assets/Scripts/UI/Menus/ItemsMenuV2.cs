using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsMenuV2 : Menu, ItemHeaderV2.ItemHeaderMaster, IEnsureVisible<ItemChoice>, ItemChoice.IItemChoiceMaster
{
    private static ItemsMenuV2 _instance;
    public static ItemsMenuV2 instance { get { return _instance != null ? _instance : new ItemsMenuV2(); } }

    public ItemsMenuV2()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    private static Selectable last_resort_default;

    private static Player player;
    private static Inventory inventory;
    public GameObject item_choice_prefab;
    public GameObject item_option_prefab;

    private static GameObject headers;
    private static Dictionary<ItemType, ItemHeaderV2> header_buttons;
    private static ItemHeaderV2 useables_header;
    private static ItemHeaderV2 potions_header;
    private static ItemHeaderV2 armors_header;
    private static ItemHeaderV2 weapons_header;
    private static ItemHeaderV2 accessories_header;
    private static ItemHeaderV2 keys_header;

    private ItemType current_header;

    private static GameObject scroll_section;
    private static Scrollbar scrollbar;
    private static GameObject item_list;
    private static RectTransform item_list_rt;
    private static HeightFitter height_fitter;

    public new void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); return; }
        else { _instance = this; }

        base.Awake();

        player = Player.instance;
        inventory = Inventory.instance;

        ItemHeaderV2.set_item_header_master(this);
        ItemChoice.set_ensure_visible_master(this);
        ItemChoice.set_item_choice_master(this);
        ItemChoice.set_item_option_prefab(item_option_prefab);

        headers = panel.Find("Item Headers").gameObject;
        header_buttons = new Dictionary<ItemType, ItemHeaderV2>();
        foreach(ItemHeaderV2 ih in headers.GetComponentsInChildren<ItemHeaderV2>(true))
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
    }

    protected override void SetDefault()
    {
        //Called automatically from menu.open()
        last_resort_default = useables_header.GetComponent<Selectable>();
        CustomEventSystem.instance.SetResetSelection(last_resort_default);
    }

    protected private void SetDefault(Selectable selectable)
    {
        CustomEventSystem.instance.SetResetSelection(selectable);
    }

    public override void open()
    {
        base.open();
        useables_header.GetComponent<Selectable>().Select();
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
        if(itemChoice.associated_item.count > 1)
        {
            SetDefault(itemChoice.selectable);
        }
        itemChoice.associated_item.use();
    }

    public void ItemEqupped(ItemChoice itemChoice)
    {
        Master.instance.set_armor(itemChoice.associated_item.id);
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
