using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FilterOption : MonoBehaviour, IPointerClickHandler
{
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
        checkmark = transform.Find("Checkmark").Find("Check Alignment Box").gameObject;
        enabled = true;
    }

    public void set_filter_master(IFilterMaster fm)
    {
        filter_master = fm;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        enabled = !enabled;
        checkmark.SetActive(enabled);
        if(!enabled) { filter_master.hide_header(type); }
        else { filter_master.show_header(type); }
    }
}
