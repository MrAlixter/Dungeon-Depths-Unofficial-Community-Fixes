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

        public virtual bool perform(ICombatant user, ICombatant target)
        {
            if(user.HUNGER + cost > 100)
            {
                message_master.set_message($"{user.name} is too hungry! {name} costs {cost} hunger!");
                return false;
            }
            //if(master.current_mode != Mode.combat && !useable_out_of_combat)
            //{
            //    message_master.set_message($"{user.name} doesn't have a target for that special!");
            //    return;
            //}
            if(cost == -1)
            {
                //Remove from options
            }
            else
            {
                user.HUNGER += cost;
            }

            message_master.display_message($"{user.name} performs {name}!");
            effect(user, target);

            return true;
        }
    }
}
