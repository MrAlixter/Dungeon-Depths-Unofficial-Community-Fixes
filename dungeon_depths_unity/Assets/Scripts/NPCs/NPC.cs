using UnityEngine;

namespace Assets.Scripts
{
    public abstract class NPC : ICombatant
    {
        protected ICombatantMaster combatantMaster;

        #region Stats
        [SerializeField]
        internal string _enemy_name;
        public string enemy_name
        {
            get { return _enemy_name; }
            protected set { _enemy_name = value; }
        }

        [SerializeField]
        internal int _HP;
        public int HP
        {
            get { return _HP; }
            protected set { _HP = value; }
        }

        [SerializeField]
        internal int _MAX_HP;
        public int MAX_HP
        {
            get { return _MAX_HP; }
            protected set { _MAX_HP = value; }
        }

        [SerializeField]
        internal int _ATK;
        public int ATK
        {
            get { return _ATK; }
            protected set { _ATK = value; }
        }

        [SerializeField]
        internal int _DEF;
        public int DEF
        {
            get { return _DEF; }
            protected set { _DEF = value; }
        }

        [SerializeField]
        internal int _SPD;
        public int SPD
        {
            get { return _SPD; }
            protected set { _SPD = value; }
        }
        #endregion

        public NPC(ICombatantMaster combatantMaster)
        {
            this.combatantMaster = combatantMaster;
        }

        public abstract void do_turn();

        public abstract void attack();

        public abstract void take_damage(int dmg);
    }
}
