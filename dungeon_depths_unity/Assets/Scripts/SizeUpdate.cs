using System;
using TMPro;
using UnityEngine;

public class SizeUpdate : MonoBehaviour
{
    RectTransform rt;
    TMP_InputField  txt;

    private void Awake()
    {
        rt = gameObject.GetComponent<RectTransform>();
        txt = gameObject.GetComponent<TMP_InputField>();
    }

    public void update_size()
    {
        float parent_size = transform.parent.GetComponent<RectTransform>().rect.height;
        rt.sizeDelta = new Vector2(rt.rect.width, Math.Max(txt.preferredHeight, parent_size));
    }
}
