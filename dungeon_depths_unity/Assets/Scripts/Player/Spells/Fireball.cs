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
        }

        public override void effect()
        {
            int dmg = 40;
            //Note that Random.value is [0, 1], unlike VB.net's Rnd() which is (0, 1]
            int d3_die1 = (int)(Random.value * 2) + 1;
            int d3_die2 = (int)(Random.value * 2) + 1;

            target.take_damage(dmg + d3_die1 + d3_die2);
        }
    }
}
