using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Spell : Ability
    {
        protected float hit_chance
        {
            get
            {
                switch(tier)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 0.9f;
                    case 3:
                        return 0.8f;
                    case 4:
                        return 0.7f;
                    case 5:
                        return 0.6f;
                    default:
                        return 0f;
                }
            }
        }
        protected float backfire_chance
        {
            get
            {
                switch (tier)
                {
                    case 1:
                    case 2:
                        return 0;
                    case 3:
                        return 0.5f;
                    case 4:
                        return 0.35f;
                    case 5:
                        return 0.2f;
                    default:
                        return 1f;
                }
            }
        }

        

        public Spell() : base()
        {
            
        }

        public void cast()
        {
            if(source.MANA < cost)
            {
                message_master.display_message("You don't have enough mana!");
                message_master.display_message($"{name} costs {cost} mana!");
                return;
            }

            if(master.current_mode != Mode.combat && !useable_out_of_combat)
            {
                message_master.display_message($"{name} requires a target!");
            }

            source.decrease_mana(cost);

            if(Random.value < hit_chance)
            {
                message_master.display_message($"You cast {name}!");
                effect();
            }
            else if(Random.value < backfire_chance)
            {
                message_master.display_message($"You cast {name} but it backfires!");
                backfire();
            }
            else
            {
                message_master.display_message($"You cast {name} but it fizzles into nothing!");
            }

            master.end_turn();
        }

        public virtual void backfire()
        {
            message_master.display_message("No backfire effect.");
        }
    }
}
