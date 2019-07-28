using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
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
    }

    public virtual void init()
    {

    }

    public void open()
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
