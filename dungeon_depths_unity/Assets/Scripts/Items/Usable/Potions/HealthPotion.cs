using UnityEngine;

namespace Assets.Scripts
{
    class HealthPotion : Potion
    {
        private static HealthPotion _instance;
        public static HealthPotion instance { get { if(_instance == null) { _instance = new HealthPotion(); } return _instance; } }

        public HealthPotion() : base()
        {
            name = "Health Potion";
            description = "A normal, everyday health potion.\n+75 health";
            id = 2;
            tier = 1;
            is_usable = true;
            count = 0;
            value = 125;
        }

        public override void use()
        {
            //If Soul-Lord, do special stuff
            message_master.display_message($"You drink the {name}");
            Player p = Player.instance;
            int amt = p.MAX_HP - p.HP;
            amt = Mathf.Min(75, amt);
            Player.instance.heal(amt);
            message_master.display_message($"You drink the {name}.\nYou heal {amt} health.");
            count--;
        }
    }
}
