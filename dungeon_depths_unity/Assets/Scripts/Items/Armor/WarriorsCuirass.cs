using UnityEngine;

public class WarriorsCuirass : Armor
{
    private static WarriorsCuirass _instance;
    public static WarriorsCuirass instance { get { return _instance != null ? _instance : new WarriorsCuirass(); } }

    public WarriorsCuirass()
    {
        if (_instance != null && _instance != this) { Destroy(this); }
        else { _instance = this; }

        name = "Warrior's Cuirass";
        description = "A protective garment made more for elite fighters rather than fashion-minded common folk.";
        id = 19;
        tier = 3;
        is_usable = false;
        attack_boost = 5;
        defense_boost = 12;
        count = 0;
        value = 950;
        slut_var_ind = 7;
        supported_sizes = new int[] { -1, 1, 2, 3 };
        fill_variants("WarriorsCuirass");
        compresses_breasts = true;
    }
}
