using UnityEngine;

public class BronzeArmor : Armor
{
    private static BronzeArmor _instance;
    public static BronzeArmor instance { get { if(_instance != null) { return _instance; } else { _instance = new BronzeArmor(); return _instance; } } }

    public void OnEnable()
    {
        if (_instance != null && _instance != this) { Destroy(this); return; }
        else { _instance = this; }

        name = "Bronze Armor";
        description = "A lightweight armor set forged from bronze that, while not offering much defence also gives a slight speed boost.";
        id = 83;
        tier = -1;
        is_usable = false;
        defense_boost = 6;
        speed_boost = 2;
        count = 0;
        value = 125;
        slut_var_ind = 85;
        supported_sizes = new int[]{ -1, 0, 1, 2, 3};
        foreach(int size in supported_sizes)
        {
            variants[size] = Resources.Load<Sprite>($"{armor_path}/BronzeArmor/{size}");
        }
        compresses_breasts = true;
    }
}
