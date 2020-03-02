using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Menu
{
    private static Gradient gradient = new Gradient();
    
    public UIRectangle base_rectangle;
    public UIRectangle bar_rectangle;
    public UnityEngine.UI.Text text;

    static HealthBar()
    {
        GradientColorKey[] colorKey = new GradientColorKey[3];
        colorKey[2].color = Color.green;
        colorKey[2].time = 1.0f;
        colorKey[1].color = Color.yellow;
        colorKey[1].time = 0.5f;
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[3];
        alphaKey[2].alpha = 1.0f;
        alphaKey[2].time = 1.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.5f;
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        gradient.SetKeys(colorKey, alphaKey);
    }

    public new void Awake()
    {
        base.Awake();
        
        //In the case of the standalone, panel is a child
        //but in the case of the battle canvas bars, 
        //panel is the root. 
        //This is handled by Menu.Start() (the base.Start() here)
        base_rectangle = panel.transform.Find("Health Bar Base").GetComponent<UIRectangle>();
        bar_rectangle = panel.transform.Find("Health Bar").GetComponent<UIRectangle>();
        text = panel.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
    }

    protected override void SetDefault()
    {
        
    }

    public void set_health(decimal current, decimal max)
    {
        float percent = (float)(current / max);
        text.text = current.ToString() + "/" + max.ToString();
        bar_rectangle.width = base_rectangle.width * percent;
        bar_rectangle.color = gradient.Evaluate(percent);
    }
}