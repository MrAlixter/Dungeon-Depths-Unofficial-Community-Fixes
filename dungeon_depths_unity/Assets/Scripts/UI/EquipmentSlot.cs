using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler, ISelectHandler, IDeselectHandler
{
    private UIRectangle background;

    private void Awake()
    {
        background = transform.Find("Background").GetComponent<UIRectangle>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
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
