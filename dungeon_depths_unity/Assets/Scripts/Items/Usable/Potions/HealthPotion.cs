using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class HealthPotion : Potion
    {
        private static HealthPotion _instance;
        public static HealthPotion instance { get { return _instance != null ? _instance : new HealthPotion(); } }

        public void OnEnable()
        {
            if (_instance != null && _instance != this) { Destroy(this); return; }
            else { _instance = this; }

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
            messageMaster.display_message($"You drink the {name}");
            Player p = Player.instance;
            int amt = p.MAX_HP - p.HP;
            amt = Math.Min(75, amt);
            Player.instance.heal(amt);
            messageMaster.display_message($"You drink the {name}.\nYou heal {amt} health.");
            count--;
        }
    }
}
