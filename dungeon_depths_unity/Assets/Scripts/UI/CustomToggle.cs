using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomToggle : Toggle
{
    private IToggleHandler toggleHandler;

    public interface IToggleHandler
    {
        void toggled();
    }

    public void set_toggle_handler(IToggleHandler th) { toggleHandler = th; }

    public override void OnSubmit(BaseEventData eventData)
    {
        toggleHandler.toggled();
    }
}
