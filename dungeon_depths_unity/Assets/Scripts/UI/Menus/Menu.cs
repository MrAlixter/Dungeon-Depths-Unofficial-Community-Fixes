using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

        Transform backgroundFade;
        if (panel.parent != null)
        {
            backgroundFade = panel.parent.Find("Background Fade");
        }
        else
        {
            backgroundFade = panel.Find("Background Fade");
        }

        if(backgroundFade != null)
        {
            OverridableButton b = backgroundFade.GetComponent<OverridableButton>();
            b.customOnClick = new OverridableButton.eventDelegate(close);
            //b.customOnSubmit
        }
    }

    public virtual void init()
    {
        SetDefault();
    }

    public virtual void open()
    {
        active = true;
        init();
    }

    public virtual void close()
    {
        //Previously selected buttons will stay selected and refuse to be unselected 
        //via any means besides selecting it and then something else. However, 
        //there's no way to see if a button/toggle is selected unless it is the 
        //event system's currently selected game object, which it almost certainly
        //won't be when the menu is reopened. 
        //To fix this, I have to unselect it before the object goes inactive
        EventSystem.current.SetSelectedGameObject(null);
        active = false;
    }

    public bool active
    {
        get { return gameObject.activeInHierarchy; }
        protected set { gameObject.SetActive(value); }
    }

    //Abstract to force children to override it so that it can be called in init()
    //This way I have to make a concious decision to not make a default button 
    //for when it's not needed (info menu and health bar).
    protected abstract void SetDefault();
}
