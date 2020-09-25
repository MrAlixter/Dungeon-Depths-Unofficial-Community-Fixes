using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FilterOption : MonoBehaviour, 
    CustomToggle.IToggleHandler, 
    ISelectHandler, 
    IDeselectHandler,
    IPointerClickHandler
{
    public CustomToggle toggle;
    //public Toggle toggle;
    public Navigation navigation { get { return selectable.navigation; } set { selectable.navigation = value; } }
    public Selectable selectable { get { return GetComponent<Selectable>(); } }
    private UIRectangle background;
    private GameObject checkmark;
    private IFilterMaster filter_master;
    private new bool enabled; //I'm not directly using the original anyway
    [SerializeField]
    private ItemType my_type; //Must be set in editor
    public ItemType type { get { return my_type; } protected set { my_type = value; } } 

    public interface IFilterMaster
    {
        void hide_header(ItemType type);
        void show_header(ItemType type);
    }

    public void Awake()
    {
        toggle = gameObject.GetComponent<CustomToggle>();
        //toggle = gameObject.GetComponent<Toggle>();
        background = transform.Find("Background").GetComponent<UIRectangle>();
        checkmark = transform.Find("Checkmark").Find("Check Alignment Box").gameObject;
        enabled = true;

        //toggle.onValueChanged.AddListener((t) => {
        //    toggled();
        //});

        toggle.init(this);
    }

    public void set_filter_master(IFilterMaster fm)
    {
        filter_master = fm;
    }

    public void OnSelect(BaseEventData eventData)
    {
        background.color = Master.highlightColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        background.color = Color.black;
    }

    private void toggled()
    {
        enabled = !enabled;
        checkmark.SetActive(enabled);
        if (!enabled) { filter_master.hide_header(type); }
        else { filter_master.show_header(type); }
    }

    void CustomToggle.IToggleHandler.toggled()
    {
        toggled();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        toggled();
    }
}
