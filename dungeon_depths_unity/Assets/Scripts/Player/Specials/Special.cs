using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Special : Ability
    {
        public Special() : base()
        {

        }

        public virtual void perform()
        {
            if(source.HUNGER + cost > 100)
            {
                message_master.set_message($"You are too hungry! {name} costs {cost} hunger!");
                return;
            }
            if(master.current_mode != Mode.combat && !useable_out_of_combat)
            {
                message_master.set_message($"You don't have a target for that special!");
                return;
            }
            if(cost == -1)
            {
                //Remove from options
            }
            else
            {
                source.add_hunger(cost);
            }

            message_master.display_message($"You perform {name}!");
            effect();

            master.end_turn();
        }
    }
}
