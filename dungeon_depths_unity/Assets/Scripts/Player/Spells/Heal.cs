using Scripts;

namespace Assets.Scripts
{
    public class Heal : Spell
    {
        public Heal() : base()
        {
            name = "Heal";
            tier = 1;
            cost = 3;
            default_target = TARGET_TYPE.SELF;
            possible_targets = TARGET_TYPE.ALL;
        }

        public override void effect(ICombatant source, ICombatant target)
        {
            int amt = target.MAX_HP / 2;
            if(amt + target.HP > target.MAX_HP) { amt = target.MAX_HP - target.HP; }

            target.HP += amt;

            if(source == target)
            {
                message_master.set_message($"${source.name} heals themself for {amt} health!");
            }
            else
            {
                message_master.set_message($"${source.name} heals ${target.name} for {amt} health!");
            }
        }
    }
}
