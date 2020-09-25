using Assets.Scripts;
using Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatMaster : ScriptableObject, ICombatMaster
{
    private static CombatMaster _instance;
    public static CombatMaster instance { get { if(_instance == null) { _instance = CreateInstance<CombatMaster>(); } return _instance; } }

    [SerializeField]
    //Meant to, eventually, be a setting
    private static float BATTLE_SPEED = 10; //Mutiplier for ATB speed where 100 makes entities with SPD == 1 attack once per second
    [SerializeField]
    //Never supposed to be changed by the user
    private static float TURN_LENGTH = 1f;

    private static IMessageMaster message_master;
    private static IModalMaster modal_master;
    private static IPlayerHealthMaster player_health_master;
    private static ITurnMaster turn_master;
    private ICombatModal combat_modal;

    private List<IPlayable> allies;
    private List<ICombatant> enemies;
    private Dictionary<ICombatant, float> ATB_amounts;
    [SerializeField]
    private Queue<ICombatant> awaiting_input_from;
    private List<ICombatant> enemies_waiting;
    private int turn_at_battle_start;
    private float time_to_next_turn = 0;
    private bool in_combat;
    
    public void Start()
    {
        message_master = Master.get_master<IMessageMaster>();
        modal_master = Master.get_master<IModalMaster>();
        player_health_master = Master.get_master<IPlayerHealthMaster>();
        turn_master = Master.get_master<ITurnMaster>();

        awaiting_input_from = new Queue<ICombatant>();
        enemies_waiting = new List<ICombatant>();

        in_combat = false;
    }
    
    public CombatMaster start_battle(List<IPlayable> allies, List<ICombatant> enemies)
    {
        this.allies = allies;
        this.enemies = enemies;

        ATB_amounts = new Dictionary<ICombatant, float>();
        allies.ForEach(c => {
            this.ATB_amounts.Add(c, 0);
            if(typeof(NPC).IsAssignableFrom(c.GetType()))
            { ((NPC)c).setCombatantMaster(this); }
        });
        enemies.ForEach(c => {
            ATB_amounts.Add(c, 0);
            if(typeof(NPC).IsAssignableFrom(c.GetType()))
            { ((NPC)c).setCombatantMaster(this); }
        });

        modal_master.try_switch_modal(MODAL.COMBAT);
        combat_modal = modal_master.get_interfaced_modal<ICombatModal>();
        combat_modal.init(allies, enemies);

        //turnMaster.in_battle = true; 

        turn_at_battle_start = turn_master.turn_number;
        time_to_next_turn = TURN_LENGTH;
        combat_modal.set_turn_text(turn_text);
        combat_modal.set_turn_percent(turn_percent);

        in_combat = true;

        return this;
    }
    
    public void Update()
    {
        if(in_combat)
        {
            if(awaiting_input_from.Count == 0)
            {
                if(enemies_waiting.Count > 0)
                {
                    List<ICombatant> temp = new List<ICombatant>(enemies_waiting);
                    foreach(ICombatant enemy in temp)
                    {
                        //Will automatically remove ATBAmount and from
                        // enemies_waiting when ending their turn.
                        // I have to use a temp variable because it doesn't like
                        // removing things (enemies who've done their turn) from 
                        // a collection being iterated through (enemies waiting)
                        ((NPC)enemy).do_turn();
                    }
                }
                else
                {
                    //Nobody else waiting for their turn
                    float baseATBAmt = Time.deltaTime / 100 * BATTLE_SPEED;

                    //Note that C# doesn't like changing dictionaries while iterating through them, 
                    //hence the separate dictionary every update
                    Dictionary<ICombatant, float> replacement = new Dictionary<ICombatant, float>();
                    foreach(KeyValuePair<ICombatant, float> kvp in ATB_amounts)
                    {
                        //Increase ATB amounts based on SPD/sec passed since last update
                        float newAmt = kvp.Value + kvp.Key.SPD * baseATBAmt;
                        if(newAmt > 1) //Percent, so 1 is ready
                        {
                            if(allies.Contains(kvp.Key))
                            {
                                awaiting_input_from.Enqueue(kvp.Key);
                                if(awaiting_input_from.Count == 1) //First in
                                {
                                    combat_modal.set_combatant_turn(kvp.Key);
                                }
                            }
                            else
                            {
                                enemies_waiting.Add(kvp.Key);
                            }
                        }
                        replacement.Add(kvp.Key, newAmt);
                    }
                    ATB_amounts = replacement;

                    time_to_next_turn -= (baseATBAmt * 10);
                    while(time_to_next_turn <= 0)
                    {
                        time_to_next_turn += TURN_LENGTH;
                        turn_master.next();
                        combat_modal.set_turn_text(turn_text);
                    }
                    combat_modal.set_turn_percent(turn_percent);
                }
                combat_modal.updateATBs(ATB_amounts);
            }
        }
    }

    public void set_battle_information(string text)
    {
        combat_modal.set_message(text);
    }

    public void add_battle_information(string text)
    {
        combat_modal.display_message(text);
    }

    public void on_battle_input_attack(ICombatant target)
    {
        ICombatant from = awaiting_input_from.Peek();

        attack(from, target);

        if(in_combat) { end_turn(from); }
    }

    public void onBattleInputAbility(ICombatant target, Ability ability)
    {
        ICombatant from = awaiting_input_from.Peek();

        bool used = true;
        if(ability is Spell) { ((Spell)ability).cast(from, target); }
        else if(ability is Special) { ((Special)ability).perform(from, target); }
        combat_modal.update_combatant_bars(from);
        combat_modal.update_combatant_bars(target);

        if (used && in_combat) { end_turn(from); }
    }

    public bool on_battle_input_run()
    {
        bool success = run(awaiting_input_from.Peek());
        if(in_combat) { end_turn(awaiting_input_from.Peek()); }

        if (success)
        {
            end_battle();
            message_master.set_message("You successfully ran from the battle!");
        }
        else
        {
            set_battle_information("You failed to run!");
        }

        return success;
    }

    public void on_battle_input_wait()
    {
        wait(awaiting_input_from.Peek());
    }
    
    public List<ICombatant> getEnemies(ICombatant forWhom)
    {
        if(allies.Contains(forWhom)) { return enemies; }
        else { return allies.Cast<ICombatant>().ToList(); }
    }

    public List<ICombatant> getAllies(ICombatant forWhom)
    {
        if (allies.Contains(forWhom)) { return allies.Cast<ICombatant>().ToList(); }
        else { return enemies; }
    }

    public void attack(ICombatant fromWhom, ICombatant toWhom)
    {
        int dmg = Formulas.calc_damage(fromWhom.ATK, toWhom.DEF);
        toWhom.take_damage(dmg);
        combat_modal.update_combatant_bars(toWhom);
        string str = $"{fromWhom.name} attacks {toWhom.name} and deals {dmg} damage!";
        if (allies.Contains(fromWhom))
        {
            //If it's a player action, clear the information
            set_battle_information(str);
        }
        else
        {
            //Otherwise add to it
            add_battle_information(str);
        }
        if(toWhom is Player)
        {

        }
    }

    public void end_turn(ICombatant forWhom)
    {
        if(awaiting_input_from.Count > 0 && awaiting_input_from.Peek().Equals(forWhom))
        {
            ATB_amounts[awaiting_input_from.Peek()] -= 1;
            combat_modal.update_single_ATB(awaiting_input_from.Peek(), ATB_amounts[awaiting_input_from.Peek()]);
            awaiting_input_from.Dequeue();
            //TODO Move TFs along
            if (awaiting_input_from.Count != 0)
            {
                combat_modal.set_combatant_turn(awaiting_input_from.Peek());
            }
            else
            {
                combat_modal.set_combatant_turn(null);
            }
        }
        else if(enemies_waiting.Contains(forWhom))
        {
            enemies_waiting.Remove(forWhom);
            ATB_amounts[forWhom] -= 1;
        }
        else
        {
            Debug.LogWarning("end_turn for Combatant who isn't available to take their turn: " + forWhom);
        }
    }

    public bool run(ICombatant whom)
    {
        if(allies.Contains(whom))
        {
            int rand_num = Random.Range(0, 3); //[0, 2]
            //Debug.Log(rand_num);
            if(rand_num == 0)
            {
                //Success message
                return true;
            }
        }
        else
        {
            //Enemy flee?
        }
        return false;
    }

    public void wait(ICombatant whom)
    {
        ATB_amounts[whom] += 0.5f;
        //TODO Perhaps it could also restore Mana?
        set_battle_information($"{whom.name} waited.");
        if(in_combat) { end_turn(whom); }
    }

    public void die(ICombatant whom)
    {
        if(whom is Player)
        {
            //TODO Player died
        }
        else if(allies.Contains(whom))
        {
            allies.Remove((IPlayable)whom);
            if (allies.Count == 0)
            {
                //TODO END COMBAT
                end_battle();
            }
            else
            {
                if (awaiting_input_from.Contains(whom))
                {
                    //Remove from queue
                    Queue<ICombatant> new_awaiting = new Queue<ICombatant>();
                    while(awaiting_input_from.Peek() != null)
                    {
                        ICombatant combatant = awaiting_input_from.Dequeue();
                        if (combatant != whom)
                        {
                            new_awaiting.Enqueue(awaiting_input_from.Dequeue());
                        }
                    }
                    awaiting_input_from = new_awaiting;
                }
                combat_modal.remove_combatant(whom);
            }
        }
        else if(enemies.Contains(whom))
        {
            enemies.Remove(whom);
            if (enemies.Count == 0)
            {
                divvy_rewards();
                end_battle();
            }
            else
            {
                if(enemies_waiting.Contains(whom)) { enemies_waiting.Remove(whom); }
                combat_modal.remove_combatant(whom);
            }
        }
        else
        {
            Debug.LogError("Combatant died who isn't an ally or enemy: " + whom);
        }

        ATB_amounts.Remove(whom);
    }

    private void divvy_rewards()
    {
        //TODO
    }

    private void end_battle()
    {
        modal_master.force_switch_modal(MODAL.NONE);
        message_master.set_message("You won the battle!");

        allies.Clear();
        enemies.Clear();
        ATB_amounts.Clear();
        awaiting_input_from.Clear();
        enemies_waiting.Clear();
        turn_at_battle_start = -1;
        time_to_next_turn = -1;
        in_combat = false;
    }

    private string turn_text { get { return $"TURN {turn_master.turn_number - turn_at_battle_start + 1} ({turn_master.turn_number})"; } }

    private float turn_percent { get { return TURN_LENGTH > 0 ? (TURN_LENGTH - time_to_next_turn) / TURN_LENGTH : 0; } }
}
