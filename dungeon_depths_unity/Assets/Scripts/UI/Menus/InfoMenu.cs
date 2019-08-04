using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : Menu
{
    private static InfoMenu _instance;
    public static InfoMenu instance { get { return _instance != null ? _instance : new InfoMenu(); } }

    public InfoMenu()
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