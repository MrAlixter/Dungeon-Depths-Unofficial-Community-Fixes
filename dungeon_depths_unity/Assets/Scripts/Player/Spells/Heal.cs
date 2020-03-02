using UnityEngine;

namespace Assets.Scripts
{
    public class Heal : Spell
    {
        public Heal() : base()
        {
            name = "Heal";
            tier = 1;
            cost = 3;
        }

        public override void effect()
        {
            int amt = source.MAX_HP / 2;
            if(amt + source.HP > source.MAX_HP) { amt = source.MAX_HP - source.HP; }

            source.heal(amt);

            message_master.set_message($"You heal yourself for {amt} health!");
        }
    }
}
