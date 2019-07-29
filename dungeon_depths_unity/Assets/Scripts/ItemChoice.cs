using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemChoice : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public static IEnsureVisible<ItemChoice> ensureVisibleMaster;

    private Item associated_item;
    private new UnityEngine.UI.Text name;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Text count;
    private UnityEngine.UI.Text value;

    public interface IItemChoiceMaster
    {
        void ItemClicked(Item item);
    }

    public void Awake()
    {
        name = transform.Find("Name").GetComponent<UnityEngine.UI.Text>();
        description = transform.Find("Description").GetComponent<UnityEngine.UI.Text>();
        count = transform.Find("Count").GetComponent<UnityEngine.UI.Text>();
        value = transform.Find("Value").GetComponent<UnityEngine.UI.Text>();
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
        ensureVisibleMaster.ensure_visible(this);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        
    }
}
