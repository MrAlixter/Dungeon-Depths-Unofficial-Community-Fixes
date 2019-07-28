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
        }

        public override void effect()
        {
            int dmg = 52;
            int d6 = (int)(Random.value * 5) + 1;

            if(d6 == 2 || d6 == 3)
            {
                //Crit
                dmg = 2*(dmg+d6);
                target.take_damage(dmg);
                message_master.display_message($"Critical hit! You hit the {target.enemy_name} for {dmg} damage!");
            }
            else
            {
                dmg = dmg + d6;
                target.take_damage(dmg);
                message_master.display_message($"You hit the {target.enemy_name} for {dmg} damage!");
            }
        }
    }
}
