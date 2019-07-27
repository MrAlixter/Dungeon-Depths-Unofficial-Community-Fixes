namespace Assets.Scripts
{
    public abstract class Ability
    {
        public int tier { get; protected set; }
        public string name { get; protected set; }
        public int cost { get; protected set; }
        public bool useable_out_of_combat { get; protected set; }

        protected static Player source;
        protected static NPC target;
        protected static Master master;
        protected static IMessageMaster message_master;

        public static void set_target(NPC t)
        {
            target = t;
        }

        public Ability()
        {
            source = Player.instance;
            master = Master.instance;
            message_master = Master.instance;
        }

        public virtual void effect()
        {
            message_master.display_message("No effect.");
        }
    }
}
