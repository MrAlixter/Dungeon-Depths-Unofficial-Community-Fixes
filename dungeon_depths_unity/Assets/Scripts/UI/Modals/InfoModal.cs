using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoModal : Modal
{
    private static InfoModal _instance;
    public static InfoModal instance { get { if(_instance != null) { return _instance; } else { _instance = new InfoModal(); return _instance; } } }

    public InfoModal()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    private UIRectangle background;
    private RectTransform background_rt;
    private UnityEngine.UI.Text text;

    public new void Awake()
    {
        base.Awake();

        background = panel.transform.Find("Background").GetComponent<UIRectangle>();
        background_rt = background.GetComponent<RectTransform>();
        text = background.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
    }

    protected override void SetDefault()
    {
        
    }

    public void set_text(string txt)
    {
        text.text = txt;
        //This isn't contraining the message at all
        //It should probably restrict it unless it's bigger than a given size
        //And then start to expand, limited to the screen size
        background_rt.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
    }
}