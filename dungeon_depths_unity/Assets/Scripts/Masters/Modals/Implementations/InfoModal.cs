using TMPro;
using UnityEngine;

public class InfoModal : Modal
{
    private UIRectangle background;
    private RectTransform background_rt;
    private TextMeshProUGUI text;

    protected override void ModalStart()
    {
        background = panel.transform.Find("Background").GetComponent<UIRectangle>();
        background_rt = background.GetComponent<RectTransform>();
        text = background.transform.Find("Text").GetComponent<TextMeshProUGUI>();
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
        //background_rt.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
    }

    public void append_text(string txt)
    {
        set_text(text.text + "\n" + txt);
    }
}