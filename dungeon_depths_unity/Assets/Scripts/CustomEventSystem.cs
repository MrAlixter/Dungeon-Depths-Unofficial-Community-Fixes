using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class CustomEventSystem : MonoBehaviour
{
    private static CustomEventSystem _instance;
    private static CustomEventSystem instance { get { return _instance != null ? _instance : new CustomEventSystem(); } }
    
    public CustomEventSystem()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    public static EventSystem getEventSystem()
    {
        return instance.GetComponent<EventSystem>();
    }
}
