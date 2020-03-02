using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatantPanel : MonoBehaviour
{
    internal ICombatant myCombatant;
    public ICombatant combatant { get { return myCombatant; } }
    Transform root;
    UIRectangle background;
    UIRectangle outline;
    Text nameText;
    RectTransform ATBRectParent;
    UIRectangle ATBRect;
    RectTransform HPRectParent;
    Text HPText;
    UIRectangle HPRect;
    RectTransform MPRectParent;
    Text MPText;
    UIRectangle MPRect;
    RectTransform HungerRectParent;
    Text HungerText;
    UIRectangle HungerRect;
    
    public void init(ICombatant combatantFor)
    {
        myCombatant = combatantFor;
        root = transform;

        background = root.Find("Background").GetComponent<UIRectangle>();
        outline = root.Find("Outline").GetComponent<UIRectangle>();
        nameText = root.Find("Name Text").GetComponent<Text>();
        Transform temp = root.Find("ATB Bar");
        ATBRectParent = root.GetComponent<RectTransform>();
        ATBRect = temp.Find("Bar").GetComponent<UIRectangle>();
        temp = root.Find("Health Bar");
        HPRectParent = root.Find("Health Bar").GetComponent<RectTransform>();
        HPText = HPRectParent.Find("HP Text").GetComponent<Text>();
        HPRect = HPRectParent.Find("HP Bar").GetComponent<UIRectangle>();
        temp = root.Find("Mana Bar");
        MPRectParent = root.Find("Mana Bar").GetComponent<RectTransform>();
        MPRect = MPRectParent.Find("MP Bar").GetComponent<UIRectangle>();
        MPText = MPRectParent.Find("MP Text").GetComponent<Text>();
        temp = root.Find("Hunger Bar");
        HungerRectParent = root.Find("Hunger Bar").GetComponent<RectTransform>();
        HungerText = HungerRectParent.Find("Hunger Text").GetComponent<Text>();
        HungerRect = HungerRectParent.Find("Hunger Bar").GetComponent<UIRectangle>();

        nameText.text = combatantFor.name;
        update_stat_bars();
    }

    public void setATBAmount(float amt)
    {
        float max = background.height - (2 * outline.thickness);
        ATBRect.height = (amt > 1 ? max : max * amt);
        //ATBRect.sizeDelta = new Vector2(ATBRect.rect.width, (amt > 1 ? max : max * amt));
        ATBRect.SetAllDirty(); //Doesn't update without this for some reason
    }

    public void update_stat_bars()
    {
        //HPRect.sizeDelta = new Vector2(HPRectParent.rect.width * myCombatant.HP / myCombatant.MAX_HP, HPRect.rect.height);
        //MPRect.sizeDelta = new Vector2(MPRectParent.rect.width * myCombatant.MANA / myCombatant.MAX_MANA, MPRect.rect.height);
        //HungerRect.sizeDelta = new Vector2(HungerRectParent.rect.width * myCombatant.HUNGER / myCombatant.MAX_HUNGER, HungerRect.rect.height);

        HPRect.width = HPRectParent.rect.width * myCombatant.HP / myCombatant.MAX_HP;
        HPRect.SetAllDirty();
        MPRect.width = MPRectParent.rect.width * myCombatant.MANA / myCombatant.MAX_MANA;
        MPRect.SetAllDirty();
        HungerRect.width = HungerRectParent.rect.width * myCombatant.HUNGER / myCombatant.MAX_HUNGER;
        HungerRect.SetAllDirty();

        HPText.text = $"{myCombatant.HP} / {myCombatant.MAX_HP}";
        MPText.text = $"{myCombatant.MANA} / {myCombatant.MAX_MANA}";
        HungerText.text = $"{myCombatant.HUNGER} / {myCombatant.MAX_HUNGER}";
    }

    public void set_acting(bool acting)
    {
        if(acting) { ATBRect.color = new Color32(210, 85, 44, 255); }
        else { ATBRect.color = new Color32(71, 139, 190, 255); }
    }

    public Selectable selectable
    {
        get
        {
            return GetComponent<Selectable>();
        }
    }

    public Navigation navigation
    {
        get
        {
            return selectable.navigation;
        }
        set
        {
            selectable.navigation = value;
        }
    }
}
