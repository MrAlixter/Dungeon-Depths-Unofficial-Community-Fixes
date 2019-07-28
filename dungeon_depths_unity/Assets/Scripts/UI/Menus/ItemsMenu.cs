using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Header { Useables, Potions, Armors, Weapons, Accessories, Misc }

public class ItemsMenu : Menu, FilterOption.IFilterMaster
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
            filter_options[fo.type] = fo;
            fo.set_filter_master(this);
        }

        foreach(KeyValuePair<Header, FilterOption> kvp in filter_options)
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

        foreach(KeyValuePair<Header, ItemHeader> header in headers)
        {
            header.Value.setItemChoicePrefab(item_choice_prefab);
            header.Value.Awake();
            header.Value.set_items_menu(this);
        }
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
        if (potionsHeader.has_children) { potionsHeader.open(); }
        else { potionsHeader.close(); }


        foreach (Armor armor in inventory.armors)
        {
            if(armor.count > 0)
            {
                armorsHeader.AddItem(armor);
            }
        }
        if(armorsHeader.has_children) { armorsHeader.open(); }
        else { armorsHeader.close(); }
        

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
}
