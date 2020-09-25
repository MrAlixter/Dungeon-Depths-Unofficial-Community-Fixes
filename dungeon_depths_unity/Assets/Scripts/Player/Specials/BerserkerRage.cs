using Scripts;

namespace Assets.Scripts
{
    public class BerserkerRage : Special
    {
        public BerserkerRage() : base()
        {
            name = "Berserker Rage";
            useable_out_of_combat = false;
            cost = -1;
            default_target = TARGET_TYPE.SELF;
            possible_targets = TARGET_TYPE.SELF;
        }

        public override void effect(ICombatant source, ICombatant target)
        {
            //CURRENTLY DOES NOTHING
            //userperk["BerserkerRage"] = 2; 
            //message_master.display_message("BERSERKER RAGE!");
            //message_master.display_message("+50% ATK and -25% DEF for 2 turns");
            message_master.set_message("Berserker Rage is not yet implemented");
        }
    }
}
