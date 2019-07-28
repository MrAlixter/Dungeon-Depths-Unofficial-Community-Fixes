using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemChoice : MonoBehaviour, IPointerClickHandler
{
    private Item associated_item;
    private UnityEngine.UI.Text name;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void LoadItem(Item item)
    {
        associated_item = item;

        name.text = item.actual_name;
        description.text = item.description;
        count.text = $"x{item.count}";
        value.text = $"{item.value} gold ea.";
    }
}
