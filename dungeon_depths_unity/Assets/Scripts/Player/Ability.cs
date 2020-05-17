using Newtonsoft.Json;
using Scripts;

namespace Assets.Scripts
{
    public abstract class Ability
    {
        public enum TARGET_TYPE { ALL, SELF, ALLY, ENEMY };

        public string type { get; set; }
        
        [JsonIgnore]
        public int tier { get; protected set; }
        [JsonIgnore]
        public string name { get; protected set; }
        [JsonIgnore]
        public int cost { get; protected set; }
        [JsonIgnore]
        public bool useable_out_of_combat { get; protected set; }
        [JsonIgnore]
        public TARGET_TYPE default_target { get; protected set; }
        [JsonIgnore]
        public TARGET_TYPE possible_targets { get; protected set; }
        
        protected static IMessageMaster message_master;
        
        public Ability()
        {
            type = GetType().FullName;
            
            message_master = Master.get_master<IMessageMaster>();
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
