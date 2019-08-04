using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomEventSystem : MonoBehaviour
{
    private static CustomEventSystem _instance;
    public static CustomEventSystem instance { get { return _instance != null ? _instance : new CustomEventSystem(); } }
    public CustomEventSystem()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    private static EventSystem es;
    private static Selectable reset;

    public void Awake()
    {
        es = EventSystem.current;
    }

    private void Update()
    {
        if (es.currentSelectedGameObject == null && reset != null)
        {
            reset.Select();
        }
    }

    //NOTE:!!! Every menu MUST call this in their open 
    //This allows the currently selected game object to automatically
    //be set if it is ever unset while in a menu (the only time it
    //matters) because it will be reselected in the Update().
    //Delescting can happen if you click with your mouse on something 
    //that isn't selectable, deselecting whatever was selected.
    public void SetResetSelection(Selectable selectable)
    {
        reset = selectable;
        reset.Select();
    }
}
