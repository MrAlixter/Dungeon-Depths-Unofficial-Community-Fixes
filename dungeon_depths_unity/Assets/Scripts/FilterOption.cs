using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FilterOption : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Toggle toggle;
    public Selectable selectable { get { return GetComponent<Selectable>(); } }
    private UIRectangle background;
    private GameObject checkmark;
    private IFilterMaster filter_master;
    private bool enabled;
    [SerializeField]
    private Header my_type; //Must be set in editor
    public Header type { get { return my_type; } protected set { my_type = value; } } 

    public interface IFilterMaster
    {
        void hide_header(Header type);
        void show_header(Header type);
    }

    public void Awake()
    {
        toggle = gameObject.GetComponent<Toggle>();
        background = transform.Find("Background").GetComponent<UIRectangle>();
        checkmark = transform.Find("Checkmark").Find("Check Alignment Box").gameObject;
        enabled = true;

        toggle.onValueChanged.AddListener((t) => {
            enabled = !enabled;
            checkmark.SetActive(enabled);
            if (!enabled) { filter_master.hide_header(type); }
            else { filter_master.show_header(type); }
        });
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
}
