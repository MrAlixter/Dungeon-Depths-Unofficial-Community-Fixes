using UnityEngine;

public class SteelArmor : Armor
{
    private static SteelArmor _instance;
    public static SteelArmor instance { get { return _instance != null ? _instance : new SteelArmor(); } }

    public void OnEnable()
    {
        if (_instance != null && _instance != this) { Destroy(this); return; }
        else { _instance = this; }

        name = "Steel Armor";
        description = "A basic armor set forged from steel.";
        id = 5;
        tier = -1;
        is_usable = false;
        defense_boost = 12;
        count = 0;
        value = 564;
        slut_var_ind = 7;
        supported_sizes = new int[] { -1, 1, 2, 3 };
        fill_variants("SteelArmor");
        compresses_breasts = true;
    }
}
