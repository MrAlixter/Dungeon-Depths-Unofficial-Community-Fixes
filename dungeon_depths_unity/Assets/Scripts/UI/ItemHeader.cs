using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemHeader : MonoBehaviour, IPointerClickHandler, ItemChoice.IItemChoiceMaster
{
    private static ItemsMenu itemsMenu;
    public void set_items_menu(ItemsMenu im)
    {
        itemsMenu = im;
    }

    private bool is_open;
    private RectTransform arrow;
    private GameObject childrenGO;
    private HeightFitter childrenHF;
    private List<GameObject> children;
    private GameObject item_choice_prefab;

    private RectTransform background_rt;
    private RectTransform children_rt;
    private RectTransform rt;

    public bool has_children { get { return children.Count > 0; } }

    public void Awake()
    {
        is_open = true;
        arrow = transform.Find("Arrow Container").Find("Triangle Container").GetComponent<RectTransform>();
        childrenGO = transform.Find("Children").gameObject;
        childrenHF = childrenGO.GetComponent<HeightFitter>();

        background_rt = transform.Find("Background").GetComponent<RectTransform>();
        children_rt = transform.Find("Children").GetComponent<RectTransform>();
        rt = GetComponent<RectTransform>();

        if(children == null) { children = new List<GameObject>(); }
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
    }

    private void resize()
    {
        float h = childrenHF.update_children();
        rt.sizeDelta = new Vector2(0, background_rt.rect.height + h);
        itemsMenu.resize();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(is_open) { close(); }
        else { open(); }
    }

    public void setItemChoicePrefab(GameObject prefab)
    {
        item_choice_prefab = prefab;
    }

    public void AddItem(Item item)
    {
        GameObject go = Instantiate(item_choice_prefab, childrenGO.transform);
        ItemChoice itemChoice = go.GetComponent<ItemChoice>();
        itemChoice.Awake();
        itemChoice.LoadItem(item);
        children.Add(go);
        float h = childrenHF.update_children();

        rt.sizeDelta = new Vector2(0, background_rt.rect.height + h);
    }

    public void ItemClicked(Item item)
    {

    }
}
