using Scripts;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public abstract class NPC : Combatant
    {
        protected ICombatantMaster combatantMaster;
        
        public void setCombatantMaster(ICombatantMaster master)
        {
            combatantMaster = master;
        }

        public override void die()
        {
            combatantMaster.die(this);
        }
    }
}
