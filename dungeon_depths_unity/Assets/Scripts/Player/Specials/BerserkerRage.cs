using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class BerserkerRage : Special
    {
        public BerserkerRage() : base()
        {
            name = "Berserker Rage";
            useable_out_of_combat = false;
            cost = -1;
        }

        public virtual void effect()
        {
            //CURRENTLY DOES NOTHING
            //userperk["BerserkerRage"] = 2; 
            message_master.display_message("BERSERKER RAGE!");
            message_master.display_message("+50% ATK and -25% DEF for 2 turns");
        }
    }
}
