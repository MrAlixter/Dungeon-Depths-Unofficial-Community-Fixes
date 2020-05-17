using Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class Fireball : Spell
    {
        public Fireball() : base()
        {
            name = "Fireball";
            tier = 1;
            cost = 4;
            default_target = TARGET_TYPE.ENEMY;
            possible_targets = TARGET_TYPE.ALL;
        }

        public override void effect(ICombatant source, ICombatant target)
        {
            int dmg = 40;
            //Note that Random.value is [0, 1], unlike VB.net's Rnd() which is [0, 1)
            int d3_die1 = (int)(Random.value * 2) + 1;
            int d3_die2 = (int)(Random.value * 2) + 1;

            message_master.set_message($"{source.name} shoots a fireball at {target.name} and does {dmg} damage!");

            target.take_damage(dmg + d3_die1 + d3_die2);
        }
    }
}
