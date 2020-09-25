using Scripts;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class TestEnemy : Enemy
    {
        public TestEnemy() : base()
        {
            MAX_HP = 65;
            HP = MAX_HP;
            ATK = 10;
            MAX_MANA = 5;
            MANA = MAX_MANA;
            MAX_HUNGER = 100;
            HUNGER = 0;
            DEF = 6;
            WIL = 5;
            SPD = 10;
            name = "Test Enemy";
        }

        public override void do_turn()
        {
            random_attack();
        }

        public void random_attack()
        {
            List<ICombatant> targets = combatantMaster.getEnemies(this);
            combatantMaster.attack(this, targets.PickRandom());
            combatantMaster.end_turn(this);
        }
    }
}