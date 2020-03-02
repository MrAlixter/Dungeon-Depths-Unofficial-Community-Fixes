namespace Assets.Scripts
{
    public abstract class Ability
    {
        public enum TARGET_TYPE { ALL, SELF, ALLY, ENEMY };

        public int tier { get; protected set; }
        public string name { get; protected set; }
        public int cost { get; protected set; }
        public bool useable_out_of_combat { get; protected set; }
        public TARGET_TYPE default_target { get; protected set; }
        public TARGET_TYPE possible_targets { get; protected set; }
        
        protected static IMessageMaster message_master;
        
        public Ability()
        {
            //master = Master.instance;
            message_master = Master.instance;
        }

        public virtual void effect(ICombatant source, ICombatant target)
        {
            message_master.display_message("No effect.");
        }

        public override string ToString()
        {
            //return base.ToString();
            return name;
        }
    }
}
