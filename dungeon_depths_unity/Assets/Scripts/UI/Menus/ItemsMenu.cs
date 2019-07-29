using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public enum Header { Useables, Potions, Armors, Weapons, Accessories, Misc }

public class ItemsMenu : Menu, FilterOption.IFilterMaster, IEnsureVisible<ItemHeader>, IEnsureVisible<ItemChoice>
{
    private static ItemsMenu _instance;
    public static ItemsMenu instance { get { return _instance != null ? _instance : new ItemsMenu(); } }
    
    public ItemsMenu()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    private static Player player;
    private static Inventory inventory;
    public GameObject item_choice_prefab;

    private static GameObject left;
    private static Dictionary<Header, FilterOption> filter_options;
    private static FilterOption useables_filter;
    private static FilterOption potions_filter;
    private static FilterOption armors_filter;
    private static FilterOption weapons_filter;
    private static FilterOption accessories_filter;
    private static FilterOption misc_filter;

    private static GameObject right;
    private static UnityEngine.UI.Scrollbar scrollbar;
    private static GameObject item_list;
    private static RectTransform item_list_rt;
    private static GameObject height_fitterGO;
    private static RectTransform height_fitter_rt;
    private static HeightFitter height_fitter;

    private static Dictionary<Header, GameObject> headerGOs;
    private static GameObject useablesHeaderGO;
    private static GameObject potionsHeaderGO;
    private static GameObject armorsHeaderGO;
    private static GameObject weaponsHeaderGO;
    private static GameObject accessoriesHeaderGO;
    private static GameObject miscHeaderGO;

    private static Dictionary<Header, ItemHeader> headers;
    private static ItemHeader useablesHeader;
    private static ItemHeader potionsHeader;
    private static ItemHeader armorsHeader;
    private static ItemHeader weaponsHeader;
    private static ItemHeader accessoriesHeader;
    private static ItemHeader miscHeader;

    public new void Awake()
    {
        base.Awake();

        player = Player.instance;
        inventory = Inventory.instance;

        left = panel.Find("Left Section").gameObject;
        Transform vertical_group = left.transform.Find("Vertical Group");
        filter_options = new Dictionary<Header, FilterOption>();
        foreach(FilterOption fo in vertical_group.GetComponentsInChildren<FilterOption>(true))
        {
            fo.Awake();
            filter_options[fo.type] = fo;
            fo.set_filter_master(this);
        }
        useables_filter = filter_options[Header.Useables];
        potions_filter = filter_options[Header.Potions];
        armors_filter = filter_options[Header.Armors];
        weapons_filter = filter_options[Header.Weapons];
        accessories_filter = filter_options[Header.Accessories];
        misc_filter = filter_options[Header.Misc];

        foreach (KeyValuePair<Header, FilterOption> kvp in filter_options)
        {
            kvp.Value.set_filter_master(this);
        }

        right = panel.Find("Right Section").gameObject;
        scrollbar = right.transform.Find("Scrollbar").GetComponent<UnityEngine.UI.Scrollbar>();
        item_list = right.transform.Find("Item List").gameObject;
        item_list_rt = item_list.GetComponent<RectTransform>();
        height_fitterGO = item_list.transform.Find("Height Fitter").gameObject;
        height_fitter_rt = item_list.GetComponent<RectTransform>();
        height_fitter = height_fitterGO.GetComponent<HeightFitter>();

        headerGOs = new Dictionary<Header, GameObject>();
        useablesHeaderGO = height_fitterGO.transform.Find("Useables Header").gameObject;
        headerGOs[Header.Useables] = useablesHeaderGO;
        potionsHeaderGO = height_fitterGO.transform.Find("Potions Header").gameObject;
        headerGOs[Header.Potions] = potionsHeaderGO;
        armorsHeaderGO = height_fitterGO.transform.Find("Armors Header").gameObject;
        headerGOs[Header.Armors] = armorsHeaderGO;
        weaponsHeaderGO = height_fitterGO.transform.Find("Weapons Header").gameObject;
        headerGOs[Header.Weapons] = weaponsHeaderGO;
        accessoriesHeaderGO = height_fitterGO.transform.Find("Accessories Header").gameObject;
        headerGOs[Header.Accessories] = accessoriesHeaderGO;
        miscHeaderGO = height_fitterGO.transform.Find("Misc Header").gameObject;
        headerGOs[Header.Misc] = miscHeaderGO;

        headers = new Dictionary<Header, ItemHeader>();
        useablesHeader = useablesHeaderGO.GetComponent<ItemHeader>();
        headers[Header.Useables] = useablesHeader;
        potionsHeader = potionsHeaderGO.GetComponent<ItemHeader>();
        headers[Header.Potions] = potionsHeader;
        armorsHeader = armorsHeaderGO.GetComponent<ItemHeader>();
        headers[Header.Armors] = armorsHeader;
        weaponsHeader = weaponsHeaderGO.GetComponent<ItemHeader>();
        headers[Header.Weapons] = weaponsHeader;
        accessoriesHeader = accessoriesHeaderGO.GetComponent<ItemHeader>();
        headers[Header.Accessories] = accessoriesHeader;
        miscHeader = miscHeaderGO.GetComponent<ItemHeader>();
        headers[Header.Misc] = miscHeader;
        
        ItemHeader previous = null;
        foreach(KeyValuePair<Header, ItemHeader> header in headers)
        {
            ItemHeader h = header.Value;
            
            FilterOption f = filter_options[header.Key];

            h.setItemChoicePrefab(item_choice_prefab);
            h.Awake();
            h.set_items_menu(this);

            Navigation nav = h.button.navigation;
            nav.selectOnLeft = f.selectable;
            if(previous != null)
            {
                previous.nextHeader = h;

                nav.selectOnUp = previous.selectable;
                Navigation n = previous.button.navigation;
                n.selectOnDown = h.selectable;
                previous.button.navigation = n;
            }
            h.button.navigation = nav;

            nav = f.toggle.navigation;
            nav.selectOnRight = h.selectable;
            f.toggle.navigation = nav;
            
            previous = h;
        }

        ItemHeader.ensureVisibleMaster = this;
        ItemChoice.ensureVisibleMaster = this;

        load_items();
    }

    public override void open()
    {
        base.open();

        useables_filter.toggle.Select();
    }

    public void load_items()
    {
        foreach (Item potion in inventory.potions)
        {
            if (potion.count > 0)
            {
                potionsHeader.AddItem(potion);
            }
        }
        potionsHeader.close();

        foreach (Armor armor in inventory.armors)
        {
            if(armor.count > 0)
            {
                armorsHeader.AddItem(armor);
            }
        }
        armorsHeader.close();

        //resize();

        scrollbar.value = 1;
    }

    public void resize()
    {
        float h = height_fitter.update_children();
        item_list_rt.offsetMin = new Vector2(0, -h);
    }

    public void hide_header(Header type)
    {
        headerGOs[type].SetActive(false);
        resize();
    }

    public void show_header(Header type)
    {
        headerGOs[type].SetActive(true);
        resize();
    }

    public void ensure_visible(ItemHeader me)
    {
        RectTransform total_rt = me.GetComponent<RectTransform>();
        RectTransform rt = me.transform.Find("Background").GetComponent<RectTransform>();

        float visible_size = right.GetComponent<RectTransform>().rect.height;
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

    public void ensure_visible(ItemChoice me)
    {
        RectTransform rt = me.GetComponent<RectTransform>();
        float child_offset = me.transform.parent.GetComponent<RectTransform>().anchoredPosition.y;
        float parent_offset = me.transform.parent.parent.GetComponent<RectTransform>().anchoredPosition.y;
        float offset = child_offset + parent_offset;

        float visible_size = right.GetComponent<RectTransform>().rect.height;
        RectTransform scroll_rt = item_list_rt;
        float scroll_offset = scroll_rt.anchoredPosition.y;
        Rect r = rt.rect;

        float top_view_offset = rt.anchoredPosition.y;
        float anchor_relative = rt.anchoredPosition.y + scroll_offset + offset;

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
            float distance_from_bottom = visible_size + anchor_relative - r.height;
            //Below the bottom
            if (distance_from_bottom < 0)
            {
                Vector2 pos = scroll_rt.anchoredPosition;
                pos.y -= distance_from_bottom;
                scroll_rt.anchoredPosition = pos;
            }
        }
    }

    private void ensure_visible(RectTransform rt, float offset)
    {
        float visible_size = right.GetComponent<RectTransform>().rect.height;
        RectTransform scroll_rt = item_list_rt;
        float scroll_offset = scroll_rt.anchoredPosition.y;
        Rect r = rt.rect;

        float top_view_offset = rt.anchoredPosition.y;

        float anchor_relative = rt.anchoredPosition.y + scroll_offset + offset;
        
        //Off the top, bring down
        if (anchor_relative > 0)
        {
            Vector2 pos = scroll_rt.anchoredPosition;
            Debug.Log($"{offset} | {visible_size} | {scroll_offset} | {top_view_offset} | {r.height} | {pos.y} | {anchor_relative}");
            pos.y -= anchor_relative;
            //Note: anchor_relative will be positive, so subtracting it will make the position closer to 0.
            //Where 0 is the scrollbar being at the top. Hence, this makes it scroll up so that the top is in view.
            scroll_rt.anchoredPosition = pos;
        }
        else
        {
            float distance_from_bottom = visible_size + anchor_relative - r.height;
            //Below the bottom
            if (distance_from_bottom < 0)
            {
                Vector2 pos = scroll_rt.anchoredPosition;
                Debug.Log($"{offset} | {visible_size} | {scroll_offset} | {top_view_offset} | {r.height} | {pos.y} | {anchor_relative} | {distance_from_bottom}");
                pos.y -= distance_from_bottom;
                scroll_rt.anchoredPosition = pos;
            }
        }
    }
}
