using Assets.Scripts;
using Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleMaster : MonoBehaviour, ICombatMaster
{
    private static IMessageMaster messageMaster;
    private static IModalMaster dialogMaster;
    private static IPlayerHealthMaster playerHealthMaster;
    private static ITurnMaster turnMaster;

    private BattleModalV2 battle_menu;

    private List<IPlayable> allies;
    private List<ICombatant> enemies;
    private Dictionary<ICombatant, float> ATBAmounts;

    [SerializeField]
    private Queue<ICombatant> awaiting_input_from;
    private List<ICombatant> enemies_waiting;

    int turn_at_battle_start;
    [SerializeField]
    //Meant to, eventually, be a setting
    private static float BATTLE_SPEED = 25; //Mutiplier for ATB speed where 100 makes entities with SPD == 1 attack once per second
    [SerializeField]
    //Never supposed to be changed by the user
    private static float TURN_LENGTH = 1f;
    [SerializeField]
    private float timeToNextTurn = 0;
    
    public static void init(IMessageMaster messageMaster, IModalMaster dialogMaster, IPlayerHealthMaster playerHealthMaster, ITurnMaster turnMaster)
    {
        BattleMaster.messageMaster = messageMaster;
        BattleMaster.dialogMaster = dialogMaster;
        BattleMaster.playerHealthMaster = playerHealthMaster;
        BattleMaster.turnMaster = turnMaster;
    }

    public static BattleMaster createInstance(GameObject parent)
    {
        BattleMaster battle_master = parent.AddComponent<BattleMaster>();
        return battle_master;
    }

    public BattleMaster startBattle(List<IPlayable> allies, List<ICombatant> enemies)
    {
        this.allies = allies;
        this.enemies = enemies;
        //player = this.allies.FirstOrDefault(a => a is Player) as Player;

        this.ATBAmounts = new Dictionary<ICombatant, float>();
        allies.ForEach(c => {
            this.ATBAmounts.Add(c, 0);
            if(typeof(NPC).IsAssignableFrom(c.GetType()))
            { ((NPC)c).setCombatantMaster(this); }
        });
        enemies.ForEach(c => {
            this.ATBAmounts.Add(c, 0);
            if(typeof(NPC).IsAssignableFrom(c.GetType()))
            { ((NPC)c).setCombatantMaster(this); }
        });
        this.awaiting_input_from = new Queue<ICombatant>();
        this.enemies_waiting = new List<ICombatant>();

        this.battle_menu = BattleModalV2.instance;
        this.battle_menu.Awake();
        this.battle_menu.init(this, playerHealthMaster, allies, enemies);

        //turnMaster.in_battle = true;
        
        dialogMaster.switch_modal(MODAL.battle);
        
        turn_at_battle_start = turnMaster.turn_number;
        timeToNextTurn = TURN_LENGTH;
        battle_menu.set_turn_text(turn_text);

        return this;
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
                float baseATBAmt = Time.deltaTime / 100 * BATTLE_SPEED;

                //Note that C# doesn't like changing dictionaries while iterating through them, 
                //hence the separate dictionary every update
                Dictionary<ICombatant, float> replacement = new Dictionary<ICombatant, float>();
                foreach (KeyValuePair<ICombatant, float> kvp in ATBAmounts)
                {
                    //Increase ATB amounts based on SPD/sec passed since last update
                    float newAmt = kvp.Value + kvp.Key.SPD * baseATBAmt;
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
                
                timeToNextTurn -= (baseATBAmt * 10);
                while(timeToNextTurn <= 0)
                {
                    timeToNextTurn += TURN_LENGTH;
                    turnMaster.next();
                    battle_menu.set_turn_text(turn_text);
                }
                float turn_percent = 0;
                if(TURN_LENGTH > 0) { turn_percent = (TURN_LENGTH - timeToNextTurn) / TURN_LENGTH; }
                //Debug.Log($"{baseATBAmt} // {timeToNextTurn} | ({TURN_LENGTH - timeToNextTurn}) / {TURN_LENGTH} == {turn_percent}%");
                battle_menu.set_turn_percent(turn_percent);
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
        battle_menu.update_combatant(toWhom);
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
        ATBAmounts[whom] += 0.5f;
        //TODO Perhaps it could also restore Mana?
        set_battle_information($"{whom.name} waited.");
        end_turn(whom);
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
                battle_menu.remove_combatant(whom);
            }
        }
        else if(enemies.Contains(whom))
        {
            enemies.Remove(whom);
            if (enemies.Count == 0)
            {
                //TODO END COMBAT
                end_battle();
            }
            else
            {
                if(enemies_waiting.Contains(whom)) { enemies_waiting.Remove(whom); }
                battle_menu.remove_combatant(whom);
            }
        }
        else
        {
            Debug.LogError("Combatant died who isn't an ally or enemy: " + whom);
        }

        ATBAmounts.Remove(whom);
    }

    private void end_battle()
    {
        dialogMaster.end_battle();
    }

    private string turn_text { get { return $"TURN {turnMaster.turn_number - turn_at_battle_start + 1} ({turnMaster.turn_number})"; } }
}
