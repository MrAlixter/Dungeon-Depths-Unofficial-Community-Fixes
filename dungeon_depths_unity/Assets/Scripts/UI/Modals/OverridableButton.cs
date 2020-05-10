using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OverridableButton : Button, ICancelHandler
{
    public delegate void eventDelegate();

    public eventDelegate customOnClick;
    public eventDelegate customOnSubmit;
    public eventDelegate customOnCancel;
    public eventDelegate customOnSelect;
    public eventDelegate customOnDeselect;

    private Selectable _selectable;
    public Selectable selectable { get { return _selectable ? _selectable : _selectable = GetComponent<Selectable>(); } set { _selectable = value; } }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        customOnClick?.Invoke();
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        base.OnSubmit(eventData);
        customOnSubmit?.Invoke();
    }

    public void OnCancel(BaseEventData eventData)
    {
        //No need to override or call the base version
        //since buttons don't have an OnCancel by default
        customOnCancel?.Invoke();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        customOnSelect?.Invoke();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        customOnDeselect?.Invoke();
    }

}