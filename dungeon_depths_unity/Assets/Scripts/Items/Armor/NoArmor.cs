public class NoArmor : Armor
{
    private static NoArmor _instance;
    public static NoArmor instance { get { if(_instance == null) { _instance = new NoArmor(); } return _instance; } }

    public NoArmor() : base()
    {
        name = "Nothing";
        description = "The birthday suit";
        id = -1;
        tier = -1;
        is_usable = false;
        defense_boost = 0;
        count = 0;
        value = 0;
        slut_var_ind = 0;
        supported_sizes = new int[] { -1, 0, 1, 2, 3, 4, 5, 6 };
        fill_variants("NoArmor");
        compresses_breasts = false;
    }
}
