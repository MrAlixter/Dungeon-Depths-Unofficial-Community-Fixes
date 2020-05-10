using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : Modal
{
    public UIRectangle hp_base_rectangle;
    public UIRectangle hp_bar_rectangle;
    public UnityEngine.UI.Text hp_text;
    public Color hp_color;

    public UIRectangle mp_base_rectangle;
    public UIRectangle mp_bar_rectangle;
    public UnityEngine.UI.Text mp_text;
    public Color mp_color;

    public UIRectangle hunger_base_rectangle;
    public UIRectangle hunger_bar_rectangle;
    public UnityEngine.UI.Text hunger_text;
    public Color hunger_color;

    static StatBar()
    {
        //GradientColorKey[] hpGCK = new GradientColorKey[3];
        //hpGCK[2].color = Color.green;
        //hpGCK[2].time = 1.0f;
        //hpGCK[1].color = Color.yellow;
        //hpGCK[1].time = 0.5f;
        //hpGCK[0].color = Color.red;
        //hpGCK[0].time = 0.0f;
        //GradientAlphaKey[] hpGAK = new GradientAlphaKey[3];
        //hpGAK[2].alpha = 1.0f;
        //hpGAK[2].time = 1.0f;
        //hpGAK[1].alpha = 1.0f;
        //hpGAK[1].time = 0.5f;
        //hpGAK[0].alpha = 1.0f;
        //hpGAK[0].time = 0.0f;
        //hp_gradient.SetKeys(hpGCK, hpGAK);

        //GradientColorKey[] mpGCK = new GradientColorKey[2];
        //mpGCK[1].color = new Color32(3, 182, 252, 255); //Light blue
        //mpGCK[1].time = 1.0f;
        //mpGCK[0].color = Color.blue; //Dark blue
        //mpGCK[0].time = 0.0f;
        //GradientAlphaKey[] mpGAK = new GradientAlphaKey[2];
        //mpGAK[1].alpha = 1.0f;
        //mpGAK[1].time = 1.0f;
        //mpGAK[0].alpha = 1.0f;
        //hpGAK[0].time = 0.0f;
        //mp_gradient.SetKeys(mpGCK, mpGAK);

        //GradientColorKey[] hungerGCK = new GradientColorKey[2];
        //mpGCK[1].color = new Color32(255, 255, 0, 255); //Yellow
        //mpGCK[1].time = 1.0f;
        //mpGCK[0].color = new Color32(255, 122, 0, 255); //Orange
        //mpGCK[0].time = 0.0f;
        //GradientAlphaKey[] hungerGAK = new GradientAlphaKey[2];
        //hungerGAK[1].alpha = 1.0f;
        //hungerGAK[1].time = 1.0f;
        //hungerGAK[0].alpha = 1.0f;
        //hungerGAK[0].time = 0.0f;
        //hunger_gradient.SetKeys(hungerGCK, hungerGAK);
    }

    public new void Awake()
    {
        base.Awake();

        //In the case of the standalone, panel is a child
        //but in the case of the battle canvas bars, 
        //panel is the root. 
        //This is handled by Menu.Awake() (the base.Awake() here)
        GameObject child = panel.transform.Find("Health Bar").gameObject;
        //Checking to see if the "Health Bar" is the parent or the bar itself
        if(child.GetComponent<UIRectangle>() == null)
        {
            //V2 of the health bar, where "Health Bar" is a container for the health bar
            //and doesn't actually have a rectangle to draw (which is actually a child)
            hp_base_rectangle = child.transform.Find("Health Bar Base").GetComponent<UIRectangle>();
            hp_bar_rectangle = child.transform.Find("Health Bar").GetComponent<UIRectangle>();
            hp_text = child.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();

            child = panel.transform.Find("Mana Bar").gameObject;
            mp_base_rectangle = child.transform.Find("Mana Bar Base").GetComponent<UIRectangle>();
            mp_bar_rectangle = child.transform.Find("Mana Bar").GetComponent<UIRectangle>();
            mp_text = child.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();

            child = panel.transform.Find("Hunger Bar").gameObject;
            hunger_base_rectangle = child.transform.Find("Hunger Bar Base").GetComponent<UIRectangle>();
            hunger_bar_rectangle = child.transform.Find("Hunger Bar").GetComponent<UIRectangle>();
            hunger_text = child.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
        }
        else
        {
            hp_base_rectangle = panel.transform.Find("Health Bar Base").GetComponent<UIRectangle>();
            hp_bar_rectangle = panel.transform.Find("Health Bar").GetComponent<UIRectangle>();
            hp_text = panel.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
        }

        hp_color = new Color(1, 0, 0);
        mp_color = new Color(0, 0.5f, 1);
        hunger_color = new Color(0, 1, 0);

        hp_bar_rectangle.color = hp_color;
        mp_bar_rectangle.color = mp_color;
        hunger_bar_rectangle.color = hunger_color;
    }

    protected override void SetDefault()
    {
        
    }

    public void set_health(decimal current, decimal max)
    {
        float percent; 
        if(max == 0) { percent = 0; }
        else { percent = (float)(current / max); }
        hp_text.text = current.ToString() + "/" + max.ToString();
        hp_bar_rectangle.width = hp_base_rectangle.width * percent;
        //hp_bar_rectangle.color = hp_gradient.Evaluate(percent);
        hp_bar_rectangle.SetVerticesDirty();
    }

    public void set_mana(decimal current, decimal max)
    {
        float percent;
        if (max == 0) { percent = 0; }
        else { percent = (float)(current / max); }
        mp_text.text = current.ToString() + "/" + max.ToString();
        mp_bar_rectangle.width = mp_base_rectangle.width * percent;
        //mp_bar_rectangle.color = mp_gradient.Evaluate(percent);
        mp_bar_rectangle.SetVerticesDirty();
    }

    public void set_hunger(decimal current, decimal max)
    {
        float percent;
        if (max == 0) { percent = 0; }
        else { percent = (float)(current / max); }
        hunger_text.text = current.ToString() + "/" + max.ToString();
        hunger_bar_rectangle.width = hunger_base_rectangle.width * percent;
        //hunger_bar_rectangle.color = hunger_gradient.Evaluate(percent);
        hunger_bar_rectangle.SetVerticesDirty();
    }
}