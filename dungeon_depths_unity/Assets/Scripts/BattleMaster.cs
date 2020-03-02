using Assets.Scripts;
using Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleMaster : MonoBehaviour, IBattleInputHandler, ICombatantMaster
{
    private IMessageMaster messageMaster;
    private IDialogMaster dialogMaster;
    private IPlayerHealthMaster playerHealthMaster;

    private BattleMenuV2 battle_menu;

    private List<ICombatant> allies;
    private List<ICombatant> enemies;
    private Dictionary<ICombatant, float> ATBAmounts;

    [SerializeField]
    private Queue<ICombatant> awaiting_input_from;
    private List<ICombatant> enemies_waiting;

    [SerializeField]
    private float BATTLE_SPEED = 25; //Mutiplier for ATB speed where 100 makes entities with SPD == 1 attack once per second
    
    public void init(IMessageMaster messageMaster, IDialogMaster dialogMaster, IPlayerHealthMaster playerHealthMaster, List<ICombatant> allies, List<ICombatant> enemies)
    {
        this.messageMaster = messageMaster;
        this.dialogMaster = dialogMaster;
        this.playerHealthMaster = playerHealthMaster;
        battle_menu = BattleMenuV2.instance;

        this.allies = allies;
        this.enemies = enemies;

        ATBAmounts = new Dictionary<ICombatant, float>();
        allies.ForEach(c => {
            ATBAmounts.Add(c, 0);
            if(typeof(NPC).IsAssignableFrom(c.GetType()))
                { ((NPC)c).setCombatantMaster(this); }
        });
        enemies.ForEach(c => {
            ATBAmounts.Add(c, 0);
            if (typeof(NPC).IsAssignableFrom(c.GetType()))
                { ((NPC)c).setCombatantMaster(this); }
        });

        awaiting_input_from = new Queue<ICombatant>();
        enemies_waiting = new List<ICombatant>();

        battle_menu.Awake();
        battle_menu.init(this, playerHealthMaster, allies, enemies);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (awaiting_input_from.Count == 0)
        {
            if (enemies_waiting.Count > 0)
            {
                List<ICombatant> temp = new List<ICombatant>(enemies_waiting);
                foreach (ICombatant enemy in temp)
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

                //Note that C# doesn't like changing dictionaries while iterating through them, 
                //hence the separate dictionary every update
                Dictionary<ICombatant, float> replacement = new Dictionary<ICombatant, float>();
                foreach (KeyValuePair<ICombatant, float> kvp in ATBAmounts)
                {
                    //Increase ATB amounts based on SPD/sec passed since last update
                    float newAmt = kvp.Value + kvp.Key.SPD * Time.deltaTime / 100 * BATTLE_SPEED;
                    if (newAmt > 1) //Percent, so 1 is ready
                    {
                        if (allies.Contains(kvp.Key))
                        {
                            awaiting_input_from.Enqueue(kvp.Key);
                            if (awaiting_input_from.Count == 1) //First in
                            {
                                battle_menu.set_combatant_turn(kvp.Key);
                            }
                        }
                        else
                        {
                            enemies_waiting.Add(kvp.Key);
                        }
                    }
                    replacement.Add(kvp.Key, newAmt);
                }
                ATBAmounts = replacement;
            }
            battle_menu.updateATBs(ATBAmounts);
        }
    }

    public void startBattle()
    {
        battle_menu.open();
    }

    public void set_battle_information(string text)
    {
        battle_menu.set_battle_information(text);
    }

    public void add_battle_information(string text)
    {
        battle_menu.add_battle_information(text);
    }

    public void onBattleInputAttack(ICombatant target)
    {
        ICombatant from = awaiting_input_from.Peek();

        attack(from, target);

        end_turn(from);
    }

    public void onBattleInputAbility(ICombatant target, Ability ability)
    {
        ICombatant from = awaiting_input_from.Peek();

        bool used = true;
        if(ability is Spell) { ((Spell)ability).cast(from, target); }
        else if(ability is Special) { ((Special)ability).perform(from, target); }
        battle_menu.update_combatant(from);
        battle_menu.update_combatant(target);

        if (used) { end_turn(from); }
    }

    public bool onBattleInputRun()
    {
        bool success = run(awaiting_input_from.Peek());
        end_turn(awaiting_input_from.Peek());

        if (success)
        {
            end_battle();
            messageMaster.display_message("You succesfuly ran from the battle!");
        }
        else
        {
            set_battle_information("You failed to run!");
        }

        return success;
    }

    public void onBattleInputWait()
    {
        wait(awaiting_input_from.Peek());
    }
    
    public List<ICombatant> getEnemies(ICombatant forWhom)
    {
        if(allies.Contains(forWhom)) { return enemies; }
        else { return allies; }
    }

    public List<ICombatant> getAllies(ICombatant forWhom)
    {
        if (allies.Contains(forWhom)) { return allies; }
        else { return enemies; }
    }

    public void attack(ICombatant from, ICombatant to)
    {
        int dmg = Formulas.calc_damage(from.ATK, to.DEF);
        to.take_damage(dmg);
        battle_menu.update_combatant(to);
        string str = $"{from.name} attacks {to.name} and deals {dmg} damage!";
        if (allies.Contains(from))
        {
            //If it's a player action, clear the information
            set_battle_information(str);
        }
        else
        {
            //Otherwise add to it
            add_battle_information(str);
        }
        if(to is Player)
        {

        }
    }

    public void end_turn(ICombatant forWhom)
    {
        if(awaiting_input_from.Count > 0 && awaiting_input_from.Peek().Equals(forWhom))
        {
            ATBAmounts[awaiting_input_from.Peek()] -= 1;
            battle_menu.update_single_ATB(awaiting_input_from.Peek(), ATBAmounts[awaiting_input_from.Peek()]);
            awaiting_input_from.Dequeue();
            //TODO Move TFs along
            if (awaiting_input_from.Count != 0)
            {
                battle_menu.set_combatant_turn(awaiting_input_from.Peek());
            }
            else
            {
                battle_menu.set_combatant_turn(null);
            }
        }
        else if(enemies_waiting.Contains(forWhom))
        {
            enemies_waiting.Remove(forWhom);
            ATBAmounts[forWhom] -= 1;
        }
        else
        {
            Debug.LogError("end_turn for Combatant who isn't available to take their turn: " + forWhom);
        }
    }

    public bool run(ICombatant who)
    {
        if(allies.Contains(who))
        {
            int rand_num = Random.Range(0, 3); //[0, 2]
            Debug.Log(rand_num);
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

    public void wait(ICombatant who)
    {
        ATBAmounts[who] += 0.5f;
        //TODO Perhaps it could also restore Mana?
        set_battle_information($"{who.name} waited.");
        end_turn(who);
    }

    public void die(ICombatant who)
    {
        if(who is Player)
        {
            //TODO Player died
        }
        else if(allies.Contains(who))
        {
            allies.Remove(who);
            if (allies.Count == 0)
            {
                //TODO END COMBAT
                end_battle();
            }
            else
            {
                if (awaiting_input_from.Contains(who))
                {
                    //Remove from queue
                    Queue<ICombatant> new_awaiting = new Queue<ICombatant>();
                    while(awaiting_input_from.Peek() != null)
                    {
                        ICombatant combatant = awaiting_input_from.Dequeue();
                        if (combatant != who)
                        {
                            new_awaiting.Enqueue(awaiting_input_from.Dequeue());
                        }
                    }
                    awaiting_input_from = new_awaiting;
                }
                battle_menu.remove_combatant(who);
            }
        }
        else if(enemies.Contains(who))
        {
            enemies.Remove(who);
            if (enemies.Count == 0)
            {
                //TODO END COMBAT
                end_battle();
            }
            else
            {
                if(enemies_waiting.Contains(who)) { enemies_waiting.Remove(who); }
                battle_menu.remove_combatant(who);
            }
        }
        else
        {
            Debug.LogError("Combatant died who isn't an ally or enemy: " + who);
        }

        ATBAmounts.Remove(who);
    }

    private void end_battle()
    {
        dialogMaster.end_battle();
    }
}
