using Assets.Scripts;
using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class MoveMap<T>
{
    public int width { get; private set; }
    public int height { get; private set; }

    public T[,] map;
    
    public MoveMap(int w, int h)
    {
        width = w;
        height = h;
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
    
    public int getWidth() { return width; }

    public int getHeight() { return height; }
}

public sealed class Master : MonoBehaviour, IMessageMaster, IEquipmentMaster, IDialogMaster, IPlayerHealthMaster
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

    [SerializeField]
    private GameObject prefabFloorTile;
    [SerializeField]
    private GameObject prefabWall;

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
    private GameObject playerCamera;
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private GameObject floorsParent;
    [SerializeField]
    private GameObject wallsParent;

    [SerializeField]
    private List<ICombatant> allies;

    [SerializeField]
    private List<ICombatant> enemies;
    private NPC enemy;


    public Mode current_mode;
    public bool player_turn;

    [SerializeField]
    private MENU current_dialog;

    [SerializeField]
    //private HealthBar health_bar;
    private StatBar stats_bar;
    [SerializeField]
    private BattleMenu battle_menu;
    [SerializeField]
    private BattleMaster battle_master;
    [SerializeField]
    private BattleMenuV2 battle_menu_v2;
    [SerializeField]
    private InfoMenu info_menu;
    [SerializeField]
    private PauseMenu pause_menu;
    [SerializeField]
    private CharacterMenu character_menu;
    [SerializeField]
    private EquipmentMenu equipment_menu;
    //[SerializeField]
    //private ItemsMenu items_menu;
    [SerializeField]
    private ItemsMenu items_menu;

    [SerializeField]
    private ProfilePicture profile_picture;
    
    // Use this for initialization
    void Start ()
	{
        floorsParent = GameObject.Find("Floors");
        wallsParent = GameObject.Find("Walls");
        System.Random r = new System.Random();
        DungeonGenerator.init(seed: r.Next(), allowTouching: false);
        DungeonGenerator.DUNGEON_TYPE[] dungeon_types = (DungeonGenerator.DUNGEON_TYPE[])Enum.GetValues(typeof(DungeonGenerator.DUNGEON_TYPE));
        Scripts.Tile[,] generated = DungeonGenerator.generate( (DungeonGenerator.DUNGEON_TYPE)dungeon_types.GetValue(r.Next(dungeon_types.Length)) );

        //Set them to get the compiler warnings to shut up 
        //Specifically to -1 to make the game crash immediately if they're not set
        if(MAP_WIDTH == 0) { MAP_WIDTH = -1; }
        if(MAP_HEIGHT == 0) { MAP_HEIGHT = -1; }
        //staticMap = new MoveMap<GameObject>(MAP_WIDTH, MAP_HEIGHT);
        //entityMap = new MoveMap<GameObject>(MAP_WIDTH, MAP_HEIGHT);

        staticMap = createMap(generated);
        entityMap = new MoveMap<GameObject>(staticMap.width, staticMap.height);

        //UnityEngine.Random.InitState(0); //Init seed to 0 for consistent testing

        current_mode = Mode.movement;
        player_turn = true;

        player = Player.instance;
        controller = Controller.instance;
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        playerCamera = GameObject.Find("Main Camera");

        placePlayer();

        ICombatant testAlly = new TestEnemy();
        testAlly.name = "Test Ally";
        allies = new List<ICombatant>() { player, testAlly };

        //Because there are health bars in the battle canvas 
        //I cannot make the health bar a singleton.
        //Thus, I must search for it at Start
        //health_bar = GameObject.Find("Stats Canvas").GetComponent<HealthBar>();
        stats_bar = GameObject.Find("Stats Canvas").GetComponent<StatBar>();

        battle_menu = BattleMenu.instance;
        battle_menu_v2 = BattleMenuV2.instance;
        info_menu = InfoMenu.instance;
        pause_menu = PauseMenu.instance;
        character_menu = CharacterMenu.instance;
        equipment_menu = EquipmentMenu.instance;
        items_menu = ItemsMenu.instance;

        profile_picture = ProfilePicture.instance;

        //update_bars();
        update_all_bars();
    }

    // Update is called once per frame
    void Update () {
        if (controller.pause_menu.down)
        {
            if(current_dialog == MENU.none && !pause_menu.active)
            {
                open_dialog(MENU.pause);
            }
            else
            {
                //Close any dialog (switch_dialog() is smart enough 
                //to prevent the battle menu from being closed
                //while in battle)
                switch_dialog(MENU.none);
            }
        }
        if (controller.character_menu.down)
        {
            if (current_dialog == MENU.none && !character_menu.active)
            {
                open_dialog(MENU.character);
            }
            else
            {
                //Close any dialog (switch_dialog() is smart enough 
                //to prevent the battle menu from being closed
                //while in battle)
                switch_dialog(MENU.none);
            }
        }
    }

    public void random_encounter()
    {
        float v = UnityEngine.Random.value * 100; //Random number on a scale of 0-100 inclusive

        //v = 0; //Force encounters on
        //v = 100; //Force encounters off

        if(v <= 0) //1/101% chance of true
        //if(v <= 11) //12/101% chance of true (default)
        {
            int enemyCount = UnityEngine.Random.Range(1, 4);

            enemies = new List<ICombatant>();
            foreach (int i in Enumerable.Range(0, enemyCount))
            {
                enemies.Add(new TestEnemy());
            }
            
            switch_dialog(MENU.battle);
        }
        //else if(v <= 22)
        //{
        //    switch_dialog(Menus.info, "This is a test dialog.\nAnd more text here.\nAnother line!");
        //}
    }

    public void next_turn()
    {
        turn++;

        //update_health_bar();
        //update_bars();
        update_health_bar();

        if(battle_menu != null && battle_menu.active)
        {
            foreach(NPC npc in enemies)
            {

            }
            battle_menu.update_turn(turn);
            battle_menu.set_battle_information(turn.ToString());
            //battle_menu.update_enemy_health(enemy.HP, enemy.MAX_HP);
            //battle_menu.update_player_health(player.HP, player.MAX_HP);
        }

        //Allow enemy to attack if in attack mode
    }

    #region Dialog Controls
    public void end_battle()
    {
        current_mode = Mode.movement;
        switch_dialog(MENU.none);
    }
    
    public void switch_dialog(MENU menu)
    {
        if(current_mode == Mode.combat) { return; }

        if(current_dialog != MENU.none)
        {
            close_dialog(current_dialog);
        }
        
        if(menu == MENU.none)
        {
            if(current_dialog == MENU.none)
            {
                current_mode = Mode.movement;
                return;
            }
        }
        else
        {
            open_dialog(menu);
        }
    }
    
    public void switch_dialog(MENU menu, string text)
    {
        switch_dialog(menu);

        if (menu == MENU.info)
        {
            set_info_dialog_text(text);
        }
    }
    
    public void close_dialog(MENU menu)
    {
        if(current_mode == Mode.combat) { return; }
        
        switch (menu)
        {
            case MENU.battle:
                close_battle_dialog();
                break;
            case MENU.character:
                close_character_dialog();
                break;
            case MENU.equipment:
                close_equipment_dialog();
                break;
            case MENU.info:
                close_info_dialog();
                break;
            case MENU.pause:
                close_pause_dialog();
                break;
            case MENU.items:
                close_items_dialog();
                break;
        }
        
        if(battle_menu_v2.active) { current_dialog = MENU.battle; }
        else if(character_menu.active) { current_dialog = MENU.character; }
        else if(equipment_menu.active) { current_dialog = MENU.equipment; }
        else if(info_menu.active) { current_dialog = MENU.info; }
        else if(pause_menu.active) { current_dialog = MENU.pause; }
        else if(items_menu.active) { current_dialog = MENU.items; }
        else { current_dialog = MENU.none; }

        if(current_dialog == MENU.none)
        {
            current_mode = Mode.movement;
        }
    }

    public void open_dialog(MENU menu)
    {
        if (current_mode == Mode.combat) { return; }

        current_dialog = menu;
        current_mode = Mode.dialog;
        switch (menu)
        {
            case MENU.battle:
                current_mode = Mode.combat;
                open_battle_dialog();
                return;
            case MENU.character:
                open_character_dialog();
                return;
            case MENU.equipment:
                open_equipment_dialog();
                return;
            case MENU.info:
                open_info_dialog();
                return;
            case MENU.pause:
                open_pause_dialog();
                return;
            case MENU.items:
                open_items_dialog();
                return;
        }
    }

    public void open_dialog(MENU menu, string text)
    {
        open_dialog(menu);
        set_info_dialog_text(text);
    }

    #region Battle Dialog Controls
    private void open_battle_dialog()
    {
        //battle_menu.Awake(); //Do any initialization necessary before loading
        battle_master = gameObject.AddComponent<BattleMaster>();
        battle_master.init(this, this, this, allies, enemies);
        battle_master.startBattle();

        //battle_menu.set_target(enemy);

        //battle_menu.set_player_name_text(player.player_name);
        //battle_menu.update_player_health(player.HP, player.MAX_HP);

        //battle_menu.set_enemy_name_text(enemy.enemy_name);
        //battle_menu.update_enemy_health(enemy.HP, enemy.MAX_HP);

        //battle_menu.update_turn(turn);
        //battle_menu.set_battle_information("");

        //battle_menu.update_stats();

        //player_turn = true;
        //battle_menu.open();
    }

    private void close_battle_dialog()
    {
        Destroy(battle_master);

        battle_menu_v2.close();
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
        items_menu.open();
    }

    private void close_items_dialog()
    {
        items_menu.close();
    }
    #endregion

    //public void update_health_bar()
    //{
    //    //health_bar.Awake();
    //    //health_bar.set_health(player.HP, player.MAX_HP);
    //    //if(battle_menu != null && battle_menu.active)
    //    //{
    //    //    battle_menu.update_player_health(player.HP, player.MAX_HP);
    //    //    battle_menu.update_enemy_health(enemy.HP, enemy.MAX_HP);
    //    //}
    //}

    //public void update_bars()
    //{
    //    update_all_bars();
    //}

    public void update_health_bar()
    {
        stats_bar.Awake();
        stats_bar.set_health(player.HP, player.MAX_HP);

        if(battle_menu != null && battle_menu.active)
        {
            battle_menu.update_player_health(player.HP, player.MAX_HP);
        }
    }

    public void update_mana_bar()
    {
        stats_bar.Awake();
        stats_bar.set_mana(player.MANA, player.MAX_MANA);
    }

    public void update_hunger_bar()
    {
        stats_bar.Awake();
        stats_bar.set_hunger(player.HUNGER, player.MAX_HUNGER);
    }

    public void update_all_bars()
    {
        update_health_bar();
        update_mana_bar();
        update_hunger_bar();
        
        //stats_bar.set_health(player.HP, player.MAX_HP);
        //stats_bar.set_mana(player.MANA, player.MAX_MANA);
        //stats_bar.set_hunger(player.HUNGER, player.MAX_HUNGER);

        if(battle_menu != null && battle_menu.active)
        {
            battle_menu.update_player_health(player.HP, player.MAX_HP);
            //battle_menu.update_enemy_health(enemy.HP, enemy.MAX_HP);
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
            int dmg = Formulas.calc_damage(player.ATK, enemy.DEF);
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
            int dmg = Formulas.calc_damage(enemy.ATK, player.DEF);
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
        int rand_num = UnityEngine.Random.Range(0, 3); //[0, 2]
        if(rand_num == 0)
        {
            //If they successfully run, it's the end of the turn
            turn++;
            current_mode = Mode.dialog;
            switch_dialog(MENU.info, "You successfully ran!");
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
        switch_dialog(MENU.info, "YOU WIN!"); //Leave combat
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
        switch_dialog(MENU.info, "YOU LOSE!"); //Leave combat
    }
    #endregion

    public void display_message(string message)
    {
        if(current_mode == Mode.combat)
        {
            //battle_menu.add_battle_information(message);
            battle_master.add_battle_information(message);
        }
        else
        {
            //open_info_dialog(message);
            open_dialog(MENU.info, message);
        }
    }

    public void set_message(string message)
    {
        if (current_mode == Mode.combat)
        {
            //battle_menu.set_battle_information(message);
            battle_master.set_battle_information(message);
        }
        else
        {
            //open_info_dialog(message);
            open_dialog(MENU.info, message);
        }
    }

    public void set_armor(int id)
    {
        player.equip_armor(id);
        if(equipment_menu.active)
        {
            equipment_menu.load_current_equipment();
        }

        update_armor();
    }

    #region Profile Picture Updating Function
    public void regenerate_profile_picture()
    {
        update_armor();
        update_body();
        update_skin_color();
        update_hair_color();
    }

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
    
    private void movePlayerAndCamera(Vector2Int p)
    {
        player.setPosition(p);
        playerCamera.transform.position = new Vector3(p.x, p.y, playerCamera.transform.position.z);
    }

    private void placePlayer()
    {
        Vector2Int newPos = new Vector2Int(-1, -1);
        int w = staticMap.getWidth();
        int h = staticMap.getWidth();

        System.Random r = new System.Random();
        while(!freeSpot(newPos))
        {
            newPos = new Vector2Int(
                r.Next(0, w),
                r.Next(0, h)
                );
        }
        movePlayerAndCamera(newPos);
    }

    public bool freeSpot(Vector2Int p)
    {
        return freeSpot(p.x, p.y);
    }

    public bool freeSpot(int x, int y)
    {
        if(x < 0 || x >= staticMap.width || y < 0 || y >= staticMap.height) { return false; }

        GameObject at = staticMap[x, y];
        if(at != null)
        {
            if(at.transform != null)
            {
                if(at.transform.parent != null)
                {
                    if(at.transform.parent.gameObject != null)
                    {
                        if(at.transform.parent.gameObject == wallsParent) { return false; }
                    }
                }
            }
        }

        at = entityMap[x, y];
        if(at != null)
        {
            if(at != player.gameObject) { return false; }
        }
        return true;
    }

    private MoveMap<GameObject> createMap(Scripts.Tile[,] inMap)
    {
        int w = inMap.GetLength(0);
        int h = inMap.GetLength(1);
        MoveMap<GameObject> ret = new MoveMap<GameObject>(w, h);

        for(int x = 0; x < w; x++)
        {
            for(int y = 0; y < h; y++)
            {
                GameObject toPut = null;
                switch(inMap[x, y])
                {
                    case Scripts.Floor inst:
                        toPut = Instantiate(prefabFloorTile, new Vector3(x, y, 0), Quaternion.identity);
                        toPut.transform.SetParent(floorsParent.transform);
                        break;
                    case Scripts.Wall inst:
                        toPut = Instantiate(prefabWall, new Vector3(x, y, 0), Quaternion.identity);
                        toPut.transform.SetParent(wallsParent.transform);
                        break;
                    default:
                        Console.WriteLine("ERROR: Found Tile of unhandled type");
                        break;
                }
                ret[x, y] = toPut;
            }
        }

        return ret;
    }
}

public enum Mode { movement, dialog, combat };