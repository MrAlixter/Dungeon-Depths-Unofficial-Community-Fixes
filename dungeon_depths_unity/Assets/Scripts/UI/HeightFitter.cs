using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightFitter : MonoBehaviour
{
    [Serializable]
    enum IncludeChildMode { activeSelf, activeInHierarchy };

    private List<RectTransform> children;
    [SerializeField]
    private IncludeChildMode mode;

    public HeightFitter()
    {
        children = new List<RectTransform>();
    }
    
    public float update_children()
    {
        RectTransform rt = GetComponent<RectTransform>();
        RectTransform parent = transform.parent.GetComponent<RectTransform>();

        children.Clear();
        foreach (RectTransform child in transform) { children.Add(child); }

        rt.sizeDelta = new Vector2(0, 0);

        float current_y = 0;
        foreach(RectTransform child in children)
        {
            //if( (mode == IncludeChildMode.activeInHierarchy && child.gameObject.activeInHierarchy) ||
            //    (mode == IncludeChildMode.activeSelf && child.gameObject.activeSelf))
            if(child.gameObject.activeSelf)
            {
                child.anchoredPosition = new Vector2(0, current_y);
                current_y -= child.rect.height;
            }
        }

        rt.sizeDelta = new Vector2(0, -current_y);
        //For some reason sizeDelta doesn't seem to be updating it immediately, 
        //so I'm returning the height for use elsewhere
        return -current_y;
    }
}
