using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpdate : MonoBehaviour
{
    RectTransform rt;
    UnityEngine.UI.InputField txt;

    // Start is called before the first frame update
    void Start()
    {
        find_components();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void find_components()
    {
        rt = gameObject.GetComponent<RectTransform>();
        txt = gameObject.GetComponent<UnityEngine.UI.InputField>();
    }

    public void update_size()
    {
        if(rt == null || txt == null) { find_components(); }
        float parent_size = transform.parent.GetComponent<RectTransform>().rect.height;
        rt.sizeDelta = new Vector2(rt.rect.width, Math.Max(txt.preferredHeight, parent_size));
    }
}
