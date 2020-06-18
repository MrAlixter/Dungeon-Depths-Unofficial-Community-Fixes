using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemChoiceButton : Button, ISubmitHandler, ICancelHandler, ISelectHandler
{
    private IItemChoiceMaster itemChoiceMaster;

    public interface IItemChoiceMaster
    {
        void ItemClicked();
        void ItemCanceled();
    }

    public void set_item_choice_master(IItemChoiceMaster icm)
    {
        itemChoiceMaster = icm;
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
    }

    public new void OnSubmit(BaseEventData eventData)
    {
        base.OnSubmit(eventData);
        itemChoiceMaster.ItemClicked();
    }

    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("ItemChoiceButton");
        itemChoiceMaster.ItemCanceled();
    }
}
