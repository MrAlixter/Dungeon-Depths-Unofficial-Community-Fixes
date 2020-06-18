using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemHeader : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public static ItemHeaderMaster itemHeaderMaster;

    public Button button;
    public Navigation navigation { get { return button.navigation; } set { button.navigation = value; } }
    public Selectable selectable { get { return button.GetComponent<Selectable>(); } }
    //vvv MUST SET IN EDITOR vvv
    public ItemType type;
    public bool selected;

    public interface ItemHeaderMaster
    {
        void load_items(ItemType type);
        void load_items();
        void selected(ItemType selected);
    }

    public static void set_item_header_master(ItemHeaderMaster ihm)
    {
        itemHeaderMaster = ihm;
    }

    public void Awake()
    {
        selected = false;
        button = GetComponent<Button>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        selected = true;
        itemHeaderMaster.selected(type);
        itemHeaderMaster.load_items(type);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selected = false;
    }
}
