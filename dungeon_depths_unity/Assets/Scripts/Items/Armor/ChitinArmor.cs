public class ChitinArmor : Armor
{
    private static ChitinArmor _instance;
    public static ChitinArmor instance { get { if(_instance == null) { _instance = new ChitinArmor(); } return _instance; } }

    public ChitinArmor() : base()
    {
        name = "Chitin Armor";
        description = "A set of armor built out of discarded chitin, commonly made and used by arachne huntresses.";
        id = 64;
        tier = 3;
        is_monster_drop = true;
        is_usable = false;
        defense_boost = 15;
        count = 0;
        value = 346;
        slut_var_ind = 7;
        supported_sizes = new int[] { -1, 1, 2, 3 };
        fill_variants("ChitinArmor");
        compresses_breasts = true;
    }
}
