using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class MoveMap<T>
{
    private int WIDTH;
    private int HEIGHT;
    
    public T[,] map;
    
    public MoveMap(int w, int h)
    {
        WIDTH = w;
        HEIGHT = h;
        map = new T[w, h];
    }
    
    public T this[int x, int y]
    {
        get { return map[x, y]; }
        set { map[x, y] = value; }
    }

    public T this[Vector2Int pos]
    {
        get { return this[pos.x, pos.y]; }
        set { this[pos.x, pos.y] = value; }
    }
    
    public int getWidth() { return WIDTH; }

    public int getHeight() { return HEIGHT; }
}

public sealed class Master : MonoBehaviour, ICombatantMaster, IMessageMaster, IEquipmentMaster
{
    private static Master _instance;
    public static Master instance { get { return _instance != null ? _instance : new Master(); } }

    public Master()
    {
        if(_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }  

    public static Color highlightColor = new Color32((byte)21, (byte)116, (byte)164, (byte)255);


    //These are currently set via the editor. 
    //Later, one maps are randonly generated, 
    //this should be set in the map generation
    [SerializeField]
    private int MAP_WIDTH;
    [SerializeField]
    private int MAP_HEIGHT;

    public MoveMap<GameObject> staticMap;
    public MoveMap<GameObject> entityMap;

    private int _turn;
    public int turn
    {
        get { return _turn; }
        private set { _turn = value; }
    }

    [SerializeField]
    private Controller controller;
    [SerializeField]
    private Player player;
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private NPC enemy;


    public Mode current_mode;
    public bool player_turn;

    [SerializeField]
    private Menus current_dialog;
    [Serializable]
    public enum Menus { none, battle, info, pause, character, equipment, items };

    [SerializeField]
    private HealthBar health_bar;
    [SerializeField]
    private BattleMenu battle_menu;
    [SerializeField]
    private InfoMenu info_menu;
    [SerializeField]
    private PauseMenu pause_menu;
    [SerializeField]
    private CharacterMenu character_menu;
    [SerializeField]
    private EquipmentMenu equipment_menu;
    [SerializeField]
    private ItemsMenu items_menu;

    [SerializeField]
    private ProfilePicture profile_picture;
    
    // Use this for initialization
    void Start ()
	{
        staticMap = new MoveMap<GameObject>(MAP_WIDTH, MAP_HEIGHT);
        entityMap = new MoveMap<GameObject>(MAP_WIDTH, MAP_HEIGHT);

        UnityEngine.Random.InitState(0); //Init seed to 0 for consistent testing

        current_mode = Mode.movement;
        player_turn = true;

        player = Player.instance;
        controller = Controller.instance;
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
        //Because there are health bars in the battle canvas 
        //I cannot make the health bar a singleton.
        //Thus, I must search for it at Start
        health_bar = GameObject.Find("Health Canvas").GetComponent<HealthBar>();

        battle_menu = BattleMenu.instance;
        info_menu = InfoMenu.instance;
        pause_menu = PauseMenu.instance;
        character_menu = CharacterMenu.instance;
        equipment_menu = EquipmentMenu.instance;
        items_menu = ItemsMenu.instance;

        profile_picture = ProfilePicture.instance;
    }

    // Update is called once per frame
    void Update () {
        if (controller.pause_menu.down)
        {
            if(current_dialog == Menus.none && !pause_menu.active)
            {
                open_dialog(Menus.pause);
            }
            else
            {
                //Close any dialog (switch_dialog() is smart enough 
                //to prevent the battle menu from being closed
                //while in battle)
                switch_dialog(Menus.none);
            }
        }
        if (controller.character_menu.down)
        {
            if (current_dialog == Menus.none && !character_menu.active)
            {
                open_dialog(Menus.character);
            }
            else
            {
                //Close any dialog (switch_dialog() is smart enough 
                //to prevent the battle menu from being closed
                //while in battle)
                switch_dialog(Menus.none);
            }
        }
    }

    public void random_encounter()
    {
        float v = UnityEngine.Random.value * 100; //Random number on a scale of 0-100 inclusive

        v = 0;

        if(v <= 11) //12/101% chance of true
        {
            switch_dialog(Menus.battle);
        }
        else if(v <= 22)
        {
            switch_dialog(Menus.info, "This is a test dialog.\nAnd more text here.\nAnother line!");
        }
    }

    public void next_turn()
    {
        turn++;

        update_health_bar();

        if(battle_menu != null && battle_menu.active)
        {
            battle_menu.update_turn(turn);
            battle_menu.set_battle_information(turn.ToString());
            battle_menu.update_enemy_health(enemy.HP, enemy.MAX_HP);
            battle_menu.update_player_health(player.HP, player.MAX_HP);
        }

        //Allow enemy to attack if in attack mode
    }

    #region Dialog Controls
    [SerializeField]
    public void switch_dialog(Menus menu)
    {
        if(current_mode == Mode.combat) { return; }

        if(current_dialog != Menus.none)
        {
            close_dialog(current_dialog);
        }

        if(menu == Menus.none)
        {
            current_dialog = menu;
            current_mode = Mode.movement;
            return;
        }
        open_dialog(menu);
    }
    
    public void switch_dialog(Menus menu, string text)
    {
        switch_dialog(menu);

        if (menu == Menus.info)
        {
            set_info_dialog_text(text);
        }
    }
    
    public void close_dialog(Menus menu)
    {
        if(current_mode == Mode.combat) { return; }

        current_dialog = Menus.none;
        current_mode = Mode.movement;
        switch (menu)
        {
            case Menus.battle:
                close_battle_dialog();
                return;
            case Menus.character:
                close_character_dialog();
                return;
            case Menus.equipment:
                close_equipment_dialog();
                return;
            case Menus.info:
                close_info_dialog();
                return;
            case Menus.pause:
                close_pause_dialog();
                return;
            case Menus.items:
                close_items_dialog();
                return;
        }
    }

    public void open_dialog(Menus menu)
    {
        if (current_mode == Mode.combat) { return; }

        current_dialog = menu;
        current_mode = Mode.dialog;
        switch (menu)
        {
            case Menus.battle:
                current_mode = Mode.combat;
                open_battle_dialog();
                return;
            case Menus.character:
                open_character_dialog();
                return;
            case Menus.equipment:
                open_equipment_dialog();
                return;
            case Menus.info:
                open_info_dialog();
                return;
            case Menus.pause:
                open_pause_dialog();
                return;
            case Menus.items:
                open_items_dialog();
                return;
        }
    }

    public void open_dialog(Menus menu, string text)
    {
        open_dialog(menu);
        set_info_dialog_text(text);
    }

    #region Battle Dialog Controls
    private void open_battle_dialog()
    {
        battle_menu.Awake(); //Do any initialization necessary before loading

        enemy = new TestEnemy(this);
        battle_menu.set_target(enemy);

        battle_menu.set_player_name_text(player.player_name);
        battle_menu.update_player_health(player.HP, player.MAX_HP);

        battle_menu.set_enemy_name_text(enemy.enemy_name);
        battle_menu.update_enemy_health(enemy.HP, enemy.MAX_HP);

        battle_menu.update_turn(turn);
        battle_menu.set_battle_information("");

        battle_menu.update_stats();
        
        player_turn = true;
        battle_menu.open();
    }

    private void close_battle_dialog()
    {
        battle_menu.close();
    }
    #endregion

    #region Info Dialog Controls
    private void open_info_dialog()
    {
        info_menu.Awake();
        
        info_menu.open();
    }

    private void open_info_dialog(string info)
    {
        info_menu.Awake();

        info_menu.set_text(info);
        info_menu.open();
    }

    private void close_info_dialog()
    {
        info_menu.close();
    }

    private void set_info_dialog_text(string info)
    {
        info_menu.set_text(info);
    }
    #endregion

    #region Pause Dialog Controls
    private void open_pause_dialog()
    {
        pause_menu.Awake();
        pause_menu.open();
    }

    private void close_pause_dialog()
    {
        pause_menu.close();
    }
    #endregion

    #region Character Dialog Controls
    private void open_character_dialog()
    {
        character_menu.open();
    }

    private void close_character_dialog()
    {
        character_menu.close();
    }
    #endregion

    #region Equipment Dialog Controls
    private void open_equipment_dialog()
    {
        equipment_menu.Awake();

        equipment_menu.load_armor_choices();
        equipment_menu.load_current_equipment();

        equipment_menu.open();
    }

    private void close_equipment_dialog()
    {
        equipment_menu.close();
    }
    #endregion

    #region Items Dialog Controls
    private void open_items_dialog()
    {
        //Unneccessary because it's now called in the Awake(), which is 
        //automatically called every time the object is set ot active
        //items_menu.Awake();
        //items_menu.load_items();

        items_menu.open();
    }

    private void close_items_dialog()
    {
        items_menu.close();
    }
    #endregion

    public void update_health_bar()
    {
        health_bar.Awake();
        health_bar.set_health(player.HP, player.MAX_HP);
        if(battle_menu != null && battle_menu.active)
        {
            battle_menu.update_player_health(player.HP, player.MAX_HP);
            battle_menu.update_enemy_health(enemy.HP, enemy.MAX_HP);
        }
    }
    #endregion

    #region Combat
    public void attack()
    {
        if(current_mode != Mode.combat)
        {
            //You have no target!
            return;
        }
        if(player_turn)
        {
            int dmg = calc_damage(player.ATK, enemy.DEF);
            enemy.take_damage(dmg);
            //Note the set here and the add forthe enemy turn
            //The actions triggered by the player reset the battle information
            //while all other stuff adds to it
            //as the player is the first to move
            //and we don't want to clear it before 
            //the player can read what their oppnent did
            battle_menu.set_battle_information("You hit the enemy for "+dmg+" damage!");
        }
        else
        {
            int dmg = calc_damage(enemy.ATK, player.DEF);
            player.take_damage(dmg);
            battle_menu.add_battle_information("You got hit for "+dmg+" damage!");
        }
    }

    public void end_turn()
    {
        if (current_mode != Mode.combat)
        {
            //There are no turns to end outside of combat!
            return;
        }
        bool death = check_death();
        if(!death)
        {
            player_turn = !player_turn;
            if (!player_turn)
            {
                battle_menu.add_battle_information("---------------");
                enemy.do_turn();
            }
            else
            {
                //Prepare for the next turn
                turn++;
                //?Have player buttons disabled between turns and then re-enable them here?
                //player.do_turn(); 
            }
            //Update data
            update_health_bar();
            battle_menu.update_turn(turn);
        }
        else
        {
            update_health_bar();
        }
        battle_menu.update_stats();
    }

    public void run()
    {
        if (current_mode != Mode.combat)
        {
            //There's nothing to run from!
            return;
        }
        int rand_num = (int)UnityEngine.Random.Range(0, 3);
        if(rand_num == 0)
        {
            //If they successfully run, it's the end of the turn
            turn++;
            current_mode = Mode.dialog;
            switch_dialog(Menus.info, "You successfully ran!");
        }
        else
        {
            //If they don't successfully run, the enemy goes, at which point the turn will end
            battle_menu.set_battle_information("You failed to run!");
            end_turn();
        }
    }

    public void wait()
    {
        if (current_mode != Mode.combat)
        {
            //???????????????
            //Can you wait outside of combat?
            return;
        }
        battle_menu.set_battle_information("You waited a turn");
        end_turn();
    }

    private int calc_damage(int atk, int def)
    {
        if(atk <= 0) { return 1; }
        if(def <= 0) { return atk; }
        return (atk * atk) / (atk + def);
    }

    private bool check_death()
    {
        if(enemy != null && enemy.HP <= 0)
        {
            victory();
            return true;
        }
        if(player.HP <= 0)
        {
            loss();
            return true;
        }
        return false;
    }

    private void victory()
    {
        //Set current mode to something else
        //to allow the battle dialog to close
        current_mode = Mode.dialog; 
        //Loot
        //WILL update
        //Victory message
        switch_dialog(Menus.info, "YOU WIN!"); //Leave combat
        //Pause/Stop battle TFs/curses
        //Death TFs/curses
        enemy = null;
    }

    private void loss()
    {
        //Set current mode to something else
        //to allow the battle dialog to close
        current_mode = Mode.dialog;
        //Reset perks
        //If save/loading, ignore
        //If regular killed, die
        //If TF killed, set health to 10% and TF death'
        //Otherwise just regular death
        enemy = null;
        switch_dialog(Menus.info, "YOU LOSE!"); //Leave combat
    }
    #endregion

    public void display_message(string message)
    {
        if(current_mode == Mode.combat)
        {
            battle_menu.add_battle_information(message);
        }
        else
        {
            open_info_dialog(message);
        }
    }

    public void set_message(string message)
    {
        if (current_mode == Mode.combat)
        {
            battle_menu.set_battle_information(message);
        }
        else
        {
            open_info_dialog(message);
        }
    }

    public void set_armor(int id)
    {
        player.equip_armor(id);
        equipment_menu.load_current_equipment();

        update_armor();
    }

    #region Profile Picture Updating Function
    public void update_armor()
    {
        profile_picture.clothes = player.equipped_armor.variants[player.breast_size];
    }

    public void update_body()
    {
        string s = player.equipped_armor.compresses_breasts ? $"{player.breast_size}c" : $"{player.breast_size}";
        profile_picture.body = profile_picture.body_pictures[s];
    }

    public void update_skin_color()
    {
        profile_picture.set_skin_color(player.skin_color);
    }

    public void update_hair_color()
    {
        profile_picture.set_hair_color(player.hair_color);
    }
    #endregion
}

public enum Mode { movement, dialog, combat };