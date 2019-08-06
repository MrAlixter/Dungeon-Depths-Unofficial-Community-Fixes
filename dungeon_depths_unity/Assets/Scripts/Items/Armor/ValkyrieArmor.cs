using UnityEngine;

public class ValkyrieArmor : Armor
{
    private static ValkyrieArmor _instance;
    public static ValkyrieArmor instance { get { return _instance != null ? _instance : new ValkyrieArmor(); } }

    public void OnEnable()
    {
        if (_instance != null && _instance != this) { Destroy(this); return; }
        else { _instance = this; }

        name = "Valkyrie Armor";
        description = "An etherial armor set crafted for a valiant defender.\nValkyries can not remove this armor.";
        id = 95;
        tier = -1;
        is_usable = false;
        defense_boost = 25;
        count = 0;
        value = 60;
        supported_sizes = new int[] { -1, 1, 2, 3 };
        fill_variants("ValkyrieArmor");
        compresses_breasts = true;
    }

    public override void discard()
    {
        //If player is a Valkyrie
        messageMaster.display_message($"You drop the {name}");
        count--;
    }
}
