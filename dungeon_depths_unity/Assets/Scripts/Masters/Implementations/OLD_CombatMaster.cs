//using Scripts;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;

//public class CombatMaster
//{
//    private static CombatMaster _instance;
//    public static CombatMaster instance { get { if(_instance == null) { _instance = new CombatMaster(); } return _instance; } }

//    //TODO remove
//    public static CombatMaster init(IModalMaster modalMaster, ITurnMaster turnMaster)
//    {
//        CombatMaster me = instance; //Create
//        instance.modalMaster = modalMaster;
//        instance.turnMaster = turnMaster;

//        return instance;
//    }


//    [SerializeField]
//    private IModalMaster modalMaster;
//    [SerializeField]
//    private ITurnMaster turnMaster;
//    [SerializeField]
//    private Player player;
//    [SerializeField]
//    private List<IPlayable> allies;
//    [SerializeField]
//    private List<ICombatant> enemies;

    


//    //public void attack()
//    //{
//    //    if(modalMaster.is_in_combat)
//    //    {
//    //        //You have no target!
//    //        return;
//    //    }
//    //    if(turnMaster.player_turn)
//    //    {
//    //        int dmg = Formulas.calc_damage(player.ATK, enemy.DEF);
//    //        enemy.take_damage(dmg);
//    //        //Note the set here and the add forthe enemy turn
//    //        //The actions triggered by the player reset the battle information
//    //        //while all other stuff adds to it
//    //        //as the player is the first to move
//    //        //and we don't want to clear it before 
//    //        //the player can read what their oppnent did
//    //        battle_menu.set_battle_information("You hit the enemy for " + dmg + " damage!");
//    //    }
//    //    else
//    //    {
//    //        int dmg = Formulas.calc_damage(enemy.ATK, player.DEF);
//    //        player.take_damage(dmg);
//    //        battle_menu.add_battle_information("You got hit for " + dmg + " damage!");
//    //    }
//    //}

//    //public void end_turn()
//    //{
//    //    if(!modalMaster.is_in_combat)
//    //    {
//    //        //There are no turns to end outside of combat!
//    //        return;
//    //    }
//    //    bool death = check_death();
//    //    if(!death)
//    //    {
//    //        player_turn = !player_turn;
//    //        if(!player_turn)
//    //        {
//    //            battle_menu.add_battle_information("---------------");
//    //            enemy.do_turn();
//    //        }
//    //        else
//    //        {
//    //            //Prepare for the next turn
//    //            turn++;
//    //            //?Have player buttons disabled between turns and then re-enable them here?
//    //            //player.do_turn(); 
//    //        }
//    //        //Update data
//    //        playerHealthMaster.update_all_bars();
//    //        battle_menu.update_turn(turn);
//    //    }
//    //    else
//    //    {
//    //        playerHealthMaster.update_all_bars();
//    //    }
//    //    battle_menu.update_stats();
//    //}

//    //public void run()
//    //{
//    //    if(!modalMaster.is_in_combat)
//    //    {
//    //        //There's nothing to run from!
//    //        return;
//    //    }
//    //    int rand_num = UnityEngine.Random.Range(0, 3); //[0, 2]
//    //    if(rand_num == 0)
//    //    {
//    //        //If they successfully run, it's the end of the turn
//    //        turn++;
//    //        modalMaster.switch_modal(MODAL.info, "You successfully ran!");
//    //    }
//    //    else
//    //    {
//    //        //If they don't successfully run, the enemy goes, at which point the turn will end
//    //        battle_menu.set_battle_information("You failed to run!");
//    //        end_turn();
//    //    }
//    //}

//    //public void wait()
//    //{
//    //    if(!modalMaster.is_in_combat)
//    //    {
//    //        //???????????????
//    //        //Can you wait outside of combat?
//    //        return;
//    //    }
//    //    battle_menu.set_battle_information("You waited a turn");
//    //    end_turn();
//    //}

//    //private bool check_death()
//    //{
//    //    if(enemy != null && enemy.HP <= 0)
//    //    {
//    //        victory();
//    //        return true;
//    //    }
//    //    if(player.HP <= 0)
//    //    {
//    //        loss();
//    //        return true;
//    //    }
//    //    return false;
//    //}

//    //private void victory()
//    //{
//    //    //Set current mode to something else
//    //    //to allow the battle dialog to close
//    //    //current_mode = MODE.dialog; 
//    //    modalMaster.end_combat_dialog("YOU WIN!");

//    //    //Loot
//    //    //WILL update

//    //    //Victory message
//    //    //switch_dialog(MODAL.info, "YOU WIN!"); //Leave combat

//    //    //Pause/Stop battle TFs/curses
//    //    //Death TFs/curses
//    //    enemy = null;
//    //}

//    //private void loss()
//    //{
//    //    //Set current mode to something else
//    //    //to allow the battle dialog to close
//    //    //current_mode = MODE.dialog;
//    //    modalMaster.end_combat_dialog("YOU LOSE!");

//    //    //Reset perks
//    //    //If save/loading, ignore
//    //    //If regular killed, die
//    //    //If TF killed, set health to 10% and TF death'
//    //    //Otherwise just regular death
//    //    enemy = null;

//    //    //switch_dialog(MODAL.info, "YOU LOSE!"); //Leave combat
//    //}
//}
