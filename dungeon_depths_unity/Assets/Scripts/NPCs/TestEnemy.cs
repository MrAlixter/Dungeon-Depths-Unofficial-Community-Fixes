using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TestEnemy : Enemy
    {
        public TestEnemy(ICombatantMaster combatantMaster) : base(combatantMaster)
        {
            MAX_HP = 85;
            HP = MAX_HP;
            ATK = 20;
            DEF = 7;
            _enemy_name = "Test Enemy";
        }

        public override void do_turn()
        {
            attack();
            combatantMaster.end_turn();
        }

        public override void attack()
        {
            combatantMaster.attack();
        }

        public override void take_damage(int dmg)
        {
            HP -= dmg;
        }
    }
}