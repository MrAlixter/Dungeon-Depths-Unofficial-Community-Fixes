using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemChoice : MonoBehaviour, 
    ISelectHandler, 
    IDeselectHandler//, 
    //ISubmitHandler,
    //ICancelHandler,
    //ItemChoiceButton.IItemChoiceMaster 
{
    public interface IItemChoiceMaster
    {
        void ItemUsed(ItemChoice itemChoice);
        void ItemEquipped(ItemChoice itemChoice);
        void ItemDiscarded(ItemChoice itemChoice);
        void ItemCanceled();
    }

    public static IEnsureVisible<ItemChoice> ensureVisibleMaster;
    public static IItemChoiceMaster itemChoiceMaster;
    private static GameObject item_option_prefab;
    
    //public ItemChoiceButton button;
    public OverridableButton button;
    public Navigation navigation { get { return button.navigation; } set { button.navigation = value; } }
    public Selectable selectable { get { return button.GetComponent<Selectable>(); } }

    public Item associated_item { get; private set; }
    private new Text name;
    private Text description;
    private Text count;
    private Text value;

    private bool options_open;
    private GameObject option_selected;
    
    public static void set_ensure_visible_master(IEnsureVisible<ItemChoice> iev)
    {
        ensureVisibleMaster = iev;
    }

    public static void set_item_choice_master(IItemChoiceMaster icm)
    {
        itemChoiceMaster = icm;
    }

    public static void set_item_option_prefab(GameObject prefab)
    {
        item_option_prefab = prefab;
    }

    public void Awake()
    {
        name = transform.Find("Name").GetComponent<Text>();
        description = transform.Find("Description").GetComponent<Text>();
        count = transform.Find("Count").GetComponent<Text>();
        value = transform.Find("Value").GetComponent<Text>();

        //button = GetComponent<ItemChoiceButton>();
        //button.set_item_choice_master(this);
        button = GetComponent<OverridableButton>();
        button.customOnSubmit = new OverridableButton.eventDelegate(ChoiceSubmitted);
        button.customOnClick = new OverridableButton.eventDelegate(ChoiceSubmitted);
        button.customOnCancel = new OverridableButton.eventDelegate(ChoiceCancelled);

        options_open = false;
        option_selected = null;
    }

    public void Update()
    {
        if(options_open && option_selected == null)
        {
            close_options();
        }
    }

    public void LoadItem(Item item)
    {
        associated_item = item;

        name.text = item.actual_name;
        description.text = item.description;
        count.text = $"x{item.count}";
        value.text = $"{item.value} gold ea.";
    }

    public void OnSelect(BaseEventData eventData)
    {
        close_options();
        ensureVisibleMaster.ensure_visible(this);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        
    }

    #region Item Choice Functions
    public void ChoiceSubmitted()
    {
        open_options();
    }

    public void ChoiceCancelled()
    {
        close_options();
        itemChoiceMaster.ItemCanceled();
    }
    #endregion

    #region Item Choice Option Functions
    public void ItemUse()
    {
        itemChoiceMaster.ItemUsed(this);
    }

    public void ItemEquip()
    {
        itemChoiceMaster.ItemEquipped(this);
    }

    public void ItemDiscard()
    {
        itemChoiceMaster.ItemDiscarded(this);
    }

    public void ItemCancelled()
    {
        button.Select();
    }

    public void ItemSelected()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        option_selected = selected;
    }

    public void ItemDeselected()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        if (selected != null)
        {
            if (selected == option_selected)
            {
                option_selected = null;
            }
        }
    }
    #endregion

    private void open_options()
    {
        GameObject go = Instantiate(item_option_prefab, transform);

        if (associated_item as Armor != null) //+Weapon
        {
            go.transform.Find("Equip").gameObject.SetActive(true);
        }
        else if (associated_item.is_usable)
        {
            go.transform.Find("Use").gameObject.SetActive(true);
        }

        go.GetComponent<HeightFitter>().update_children();

        Selectable parent_selectable = GetComponent<Selectable>();
        bool first = true;
        Selectable previous = null;
        Navigation nav;
        foreach (Transform child in go.transform)
        {
            OverridableButton current_button = child.GetComponent<OverridableButton>();
            if(child.name.Equals("Use")) { current_button.customOnSubmit = new OverridableButton.eventDelegate(ItemUse); }
            else if(child.name.Equals("Equip")) { current_button.customOnSubmit = new OverridableButton.eventDelegate(ItemEquip); }
            else if(child.name.Equals("Discard")) { current_button.customOnSubmit = new OverridableButton.eventDelegate(ItemDiscard); }
            current_button.customOnClick = current_button.customOnSubmit;
            current_button.customOnCancel = new OverridableButton.eventDelegate(ItemCancelled);
            current_button.customOnSelect = new OverridableButton.eventDelegate(ItemSelected);
            current_button.customOnDeselect = new OverridableButton.eventDelegate(ItemDeselected);

            Selectable current = current_button.selectable;
            if (child.gameObject.activeSelf)
            {
                if (first)
                {
                    nav = current.navigation;
                    nav.selectOnUp = parent_selectable;
                    current.navigation = nav;

                    current.Select();

                    first = false;
                }

                if (previous != null)
                {
                    nav = current.navigation;
                    nav.selectOnUp = previous;
                    current.navigation = nav;

                    nav = previous.navigation;
                    nav.selectOnDown = current;
                    previous.navigation = nav;
                }

                nav = current.navigation;
                nav.selectOnLeft = parent_selectable;
                nav.selectOnRight = parent_selectable;
                current.navigation = nav;

                previous = current;
            }
        }
        nav = previous.navigation;
        nav.selectOnDown = parent_selectable;
        previous.navigation = nav;

        options_open = true;
    }

    private void close_options()
    {
        Transform t = transform.Find("ItemOptions(Clone)");
        if (t != null)
        {
            Destroy(t.gameObject);
        }
        options_open = false;
    }
}
