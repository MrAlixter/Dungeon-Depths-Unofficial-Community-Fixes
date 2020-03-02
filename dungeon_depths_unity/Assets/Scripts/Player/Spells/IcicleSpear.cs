using UnityEngine;

namespace Assets.Scripts
{
    public class IcicleSpear : Spell
    {
        public IcicleSpear() : base()
        {
            name = "Icicle Spear";
            tier = 2;
            cost = 5;
            default_target = TARGET_TYPE.ENEMY;
            possible_targets = TARGET_TYPE.ALL;
        }

        public override void effect(ICombatant source, ICombatant target)
        {
            int dmg = 52;
            int d6 = (int)(Random.value * 5) + 1;

            if(d6 == 2 || d6 == 3)
            {
                //Crit
                dmg = 2*(dmg+d6);
                message_master.set_message($"Critical hit! ${source.name} hit the {target.name} for {dmg} damage!");
                target.take_damage(dmg);
            }
            else
            {
                dmg = dmg + d6;
                message_master.set_message($"{source.name} hit the {target.name} for {dmg} damage!");
                target.take_damage(dmg);
            }
        }
    }
}
