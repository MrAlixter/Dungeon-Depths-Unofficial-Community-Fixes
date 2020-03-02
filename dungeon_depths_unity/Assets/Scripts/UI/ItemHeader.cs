using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
public class ItemHeader : MonoBehaviour, ItemChoice.IItemChoiceMaster, ISelectHandler, IDeselectHandler
{
    public static IEnsureVisible<ItemHeader> ensureVisibleMaster;
    private static ItemsMenu itemsMenu;
    public void set_items_menu(ItemsMenu im)
    {
        itemsMenu = im;
    }

    private bool awoken = false;

    public Button button { get; set; }
    public Selectable selectable { get { return GetComponent<Selectable>(); } }
    [SerializeField]
    private bool is_open;
    private RectTransform arrow;
    private GameObject childrenGO;
    private HeightFitter childrenHF;
    private List<GameObject> children;
    private static GameObject item_choice_prefab;

    private RectTransform background_rt;
    private RectTransform children_rt;
    private RectTransform rt;

    public ItemHeader nextHeader;

    public bool has_children { get { return children.Count > 0; } }

    public static void setItemChoicePrefab(GameObject prefab)
    {
        ItemHeader.item_choice_prefab = prefab;
    }

    public void Awake()
    {
        //To prevent double calls
        if(awoken) { return; }
        awoken = true;

        is_open = true;

        button = GetComponent<Button>();
        arrow = transform.Find("Arrow Container").Find("Triangle Container").GetComponent<RectTransform>();
        childrenGO = transform.Find("Children").gameObject;
        childrenHF = childrenGO.GetComponent<HeightFitter>();

        background_rt = transform.Find("Background").GetComponent<RectTransform>();
        children_rt = transform.Find("Children").GetComponent<RectTransform>();
        rt = GetComponent<RectTransform>();

        if(children == null) { children = new List<GameObject>(); }
        button.onClick.AddListener(() => {
            if (is_open) { close(); }
            else { open(); }
        });
    }

    public void open()
    {
        //Reset to 0
        arrow.transform.rotation = Quaternion.identity;
        //Then rotate to the correct position
        arrow.transform.Rotate(new Vector3(0, 0, -90));

        childrenGO.SetActive(true);
        //Typically the SetActive above would have been enough,
        //but for some reason I couldn't get height fitter to 
        //handle it properly, so I'm just manually disabling 
        //all the children as well to just avoid the issue
        foreach(GameObject go in children)
        {
            go.SetActive(true);
        }

        is_open = true;

        resize();

        //If it has children, then it needs to update its navigation to go to the first child
        //and update the next header to go to the last child
        if(has_children)
        {
            Navigation nav = button.navigation;
            nav.selectOnDown = children[0].GetComponent<Selectable>();
            button.navigation = nav;
            
            nav = nextHeader.button.navigation;
            nav.selectOnUp = children[children.Count - 1].GetComponent<Selectable>();
            nextHeader.button.navigation = nav;
        }
    }

    public void close()
    {
        //Reset to 0
        arrow.transform.rotation = Quaternion.identity;

        childrenGO.SetActive(false);
        foreach (GameObject go in children)
        {
            go.SetActive(false);
        }

        is_open = false;

        resize();

        //If it has children, then it needs to update its navigation to go the next header instead
        //and make the next header point to itself
        if (has_children)
        {
            Navigation nav = button.navigation;
            nav.selectOnDown = nextHeader.selectable;
            button.navigation = nav;

            nav = nextHeader.button.navigation;
            nav.selectOnUp = selectable;
            nextHeader.button.navigation = nav;
        }
    }

    private void resize()
    {
        float h = childrenHF.update_children();
        rt.sizeDelta = new Vector2(0, background_rt.rect.height + h);
        itemsMenu.resize();
    }

    public void AddItem(Item item)
    {
        GameObject go = Instantiate(ItemHeader.item_choice_prefab, childrenGO.transform);
        ItemChoice itemChoice = go.GetComponent<ItemChoice>();
        itemChoice.Awake();
        itemChoice.LoadItem(item);
        children.Add(go);
        float h = childrenHF.update_children();

        rt.sizeDelta = new Vector2(0, background_rt.rect.height + h);

        rebuild_child_navigation();
    }

    private void rebuild_child_navigation()
    {
        Navigation nav;
        GameObject previous = null;
        //Set all as normal
        foreach(GameObject go in children)
        {
            Button this_button = go.GetComponent<Button>();
            if (previous != null)
            {
                Button last_button = previous.GetComponent<Button>();
                
                nav = this_button.navigation;
                nav.selectOnUp = last_button.GetComponent<Selectable>();
                this_button.navigation = nav;

                nav = last_button.navigation;
                nav.selectOnDown = this_button.GetComponent<Selectable>();
                last_button.navigation = nav;
            }
            nav = this_button.navigation;
            nav.selectOnLeft = button.navigation.selectOnLeft;
            this_button.navigation = nav;

            previous = go;
        }

        Button to_set;
        //Then set first
        to_set = children[0].GetComponent<Button>();
        nav = to_set.navigation;
        nav.selectOnUp = this.selectable;
        to_set.navigation = nav;

        //And last
        to_set = children[children.Count - 1].GetComponent<Button>();
        nav = to_set.navigation;
        nav.selectOnDown = nextHeader.selectable;
        to_set.navigation = nav;
    }

    public void ItemClicked(Item item)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSelect(BaseEventData eventData)
    {
        //throw new System.NotImplementedException();
        ensureVisibleMaster.ensure_visible(this);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
*/