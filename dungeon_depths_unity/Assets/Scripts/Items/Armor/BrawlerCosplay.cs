using UnityEngine;

public class BrawlerCosplay : Armor
{
    private static BrawlerCosplay _instance;
    public static BrawlerCosplay instance { get { return _instance != null ? _instance : new BrawlerCosplay(); } }

    public void OnEnable()
    {
        if (_instance != null && _instance != this) { Destroy(this); return; }
        else { _instance = this; }

        name = "Brawler Cosplay";
        description = "A glamourous garment made more for the highlighting one's body than for any practical function.";
        id = 20;
        tier = -1;
        is_usable = false;
        defense_boost = 6;
        attack_boost = 5;
        count = 0;
        value = 1250;
        anti_slut_var_ind = 19;
        supported_sizes = new int[]{ -1, 1, 2, 3};
        fill_variants("BrawlerCosplay");
        compresses_breasts = true;
    }
}
