using UnityEngine;

public class GoldArmor : Armor
{
    private static GoldArmor _instance;
    public static GoldArmor instance { get { return _instance != null ? _instance : new GoldArmor(); } }
    
    public GoldArmor()
    {
        if (_instance != null && _instance != this) { Destroy(this); }
        else { _instance = this; }

        name = "Gold Armor";
        description = "An expensive looking armor set made for the wealthy.";
        id = 38;
        tier = -1;
        is_usable = false;
        defense_boost = 30;
        count = 0;
        value = 3800;
        slut_var_ind = 39;
        supported_sizes = new int[] { -1, 1, 2, 3 };
        fill_variants("GoldArmor");
        compresses_breasts = true;
    }
}
