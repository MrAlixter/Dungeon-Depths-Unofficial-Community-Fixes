using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Menu : MonoBehaviour
{
    protected static EventSystem eventSystem;
    protected RectTransform panel;

    public void Awake()
    {
        Transform p = transform.Find("Panel");
        if(p != null) //If it's child is where the panel is...
        {
            panel = p.GetComponent<RectTransform>();
        }
        else //Otherwise, it is the panel
        {
            panel = GetComponent<RectTransform>();
        }

        eventSystem = CustomEventSystem.getEventSystem();
    }

    public virtual void init()
    {

    }

    public virtual void open()
    {
        active = true;
        init();
    }

    public void close()
    {
        active = false;
    }

    public bool active
    {
        get { return gameObject.activeInHierarchy; }
        protected set { gameObject.SetActive(value); }
    }
}
