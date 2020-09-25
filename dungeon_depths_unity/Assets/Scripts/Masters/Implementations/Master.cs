using Assets.Scripts;
using Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

[Savable]
public sealed class Master : MonoBehaviour, IGameMaster
{
    public static Master instance { get; private set; }

    public static Color highlightColor = new Color32((byte)21, (byte)116, (byte)164, (byte)255);
    public enum PLACE_PLAYER_AT_RANDOM { NO, YES, IF_NEW }
    private char sep = Path.DirectorySeparatorChar;

    System.Random rng;
    System.Random floorRng;

    //These are currently set via the editor. 
    //Later, one maps are randonly generated, 
    //this should be set in the map generation
    [Savable]
    [SerializeField]
    private int MAP_WIDTH;
    [Savable]
    [SerializeField]
    private int MAP_HEIGHT;

    
    private int floorSeed { get { return floorSeeds[floorNum]; } }
    [Savable]
    private List<int> floorSeeds;
    [Savable]
    [SerializeField]
    private int floorNum;
    [Savable]
    public Vector2Int stairsUp;
    [Savable]
    public Vector2Int stairsDown;
    [Savable]
    private List<MoveMap<Tile>> staticMaps;
    [Savable]
    private List<MoveMap<Tile>> fogMaps;
    
    private GameObject prefabFloorTile;
    private GameObject prefabWall;
    private GameObject prefabStairsUp;
    private GameObject prefabStairsDown;
    private GameObject prefabFog;

    public MoveMap<Tile> staticMap
    {
        get
        {
            return staticMaps[floorNum];
        }
        set
        {
            if(staticMaps.Count < floorNum)
            {
                staticMaps.Add(value);
            }
            else
            {
                staticMaps[floorNum] = value;
            }
        }
    }
    public MoveMap<Tile> fogMap
    {
        get
        {
            return fogMaps[floorNum];
        }
        set
        {
            if(fogMaps.Count < floorNum)
            {
                fogMaps.Add(value);
            }
            else
            {
                fogMaps[floorNum] = value;
            }
        }
    }
    
    private Player player;
    
    private GameObject floorsParent;
    private GameObject wallsParent;
    private GameObject othersParent;
    private GameObject fogParent;

    private Dictionary<Type, object> masters;
    private IPlayerHealthMaster player_health_master;
    private IModalMaster modal_master;
    private ITurnMaster turn_master;
    private ICombatMaster combat_master;
    private IStatsBar stats_bar;
    private IProfilePictureMaster profile_picture_master;
    private ISaveMaster save_master;
    private IMessageMaster message_master;
    private ICameraMaster camera_master;
    private IBattleInputHandler battle_input_handler;

    Tweener tweener;

    void Awake()
    //void Start()
	{
        //InputControlScheme.
        //onActionTriggered
        instance = this;

        floorNum = 0;
        staticMaps = new List<MoveMap<Tile>>();
        fogMaps = new List<MoveMap<Tile>>();
        floorSeeds = new List<int>();
        masters = new Dictionary<Type, object>();
        #region Map sizes
        //Set them to get the compiler warnings to shut up 
        //Specifically to -1 to make the game crash immediately if they're not set
        if(MAP_WIDTH == 0) { MAP_WIDTH = -1; }
        if(MAP_HEIGHT == 0) { MAP_HEIGHT = -1; }
        #endregion
        #region Prefabs
        prefabFloorTile = Resources.Load<GameObject>("Prefabs" + sep + "Tiles" + sep + "FloorTile");
        prefabWall = Resources.Load<GameObject>("Prefabs" + sep + "Tiles" + sep + "Wall");
        prefabStairsUp = Resources.Load<GameObject>("Prefabs" + sep + "Tiles" + sep + "StairsUp");
        prefabStairsDown = Resources.Load<GameObject>("Prefabs" + sep + "Tiles" + sep + "StairsDown");
        prefabFog = Resources.Load<GameObject>("Prefabs" + sep + "Tiles" + sep + "Fog");
        #endregion

        tweener = Tweener.instance;
    }
    
    void Start()
    {
        Player.input.UI.PauseMenu.performed += ctx => open_pause_menu();
        Player.input.UI.CharacterMenu.performed += ctx => open_character_menu();

        Player.input.Player.PauseMenu.performed += ctx => open_pause_menu();
        Player.input.Player.CharacterMenu.performed += ctx => open_character_menu();
        Player.input.Player.Interact.performed += ctx => interact();
        

        rng = new System.Random();

        player = Player.instance;
        
        turn_master = TurnMaster.init(1);//, true);
        profile_picture_master = ProfilePicture.instance;
        modal_master = ModalMaster.init(MODAL.NONE, MODE.MOVEMENT);
        save_master = SaveMaster.instance;
        message_master = MessageMaster.instance;
        camera_master = CameraMaster.instance;
        combat_master = CombatMaster.instance;
        player_health_master = PlayerHealthMaster.instance;

        masters.Add(typeof(IModalMaster), modal_master);
        masters.Add(typeof(IPlayerHealthMaster), player_health_master);
        masters.Add(typeof(ITurnMaster), turn_master);
        masters.Add(typeof(ICombatMaster), combat_master);
        masters.Add(typeof(IBattleInputHandler), combat_master);
        masters.Add(typeof(ICombatantMaster), combat_master);
        masters.Add(typeof(IProfilePictureMaster), profile_picture_master);
        masters.Add(typeof(IMessageMaster), message_master);
        masters.Add(typeof(IGameMaster), this);
        masters.Add(typeof(ISaveMaster), save_master);
        masters.Add(typeof(ICameraMaster), camera_master);

        //The Abiliy constructor is call too soon to be able to grab an IMessageMaster, 
        // so I'm calling it here via one of its implementations. Doesn't have to be Heal. 
        Heal heal = new Heal(); 

        //Any ScriptableObject masters who need to fetch another master can do so now
        //However, since ScriptableObjects don't have Start(), I have to do it manually
        //Although, I'm still making them make their Start() public.
        foreach(object master in masters.Values)
        {
            if(master is ScriptableObject)
            {
                MethodInfo mi = master.GetType().GetMethod("Start");
                if(mi != null)
                {
                    mi.Invoke(master, null);
                }
            }
        }

        modal_master.try_switch_modal(MODAL.MAIN);
    }

    public void open_pause_menu()
    {
        if(modal_master.is_in_movement)
        {
            modal_master.try_switch_modal(MODAL.PAUSE);
        }
        else { modal_master.try_switch_modal(MODAL.NONE); }
    }
    public void open_character_menu()
    {
        if(modal_master.is_in_movement)
        {
            modal_master.try_switch_modal(MODAL.CHARACTER);
        }
        else { modal_master.try_switch_modal(MODAL.NONE); }
    }
    public void interact()
    {
        if(staticMap[player.position] != null)
        {
            Tile objAt = staticMap[player.position];
            if(objAt.type == Tile.TILE_TYPE.STAIRS_DOWN)
            {
                go_down_a_floor();
            }
            else if(objAt.type == Tile.TILE_TYPE.STAIRS_UP)
            {
                go_up_a_floor();
            }
        }
    }

    void Update()
    {
        tweener.Update();
        combat_master?.Update(); //TODO Make into own MonoBehavior instead of ScriptableObject?
    }

    public static T get_master<T>()
    {
        return (T)instance.get_master_from_type(typeof(T));
    }

    private object get_master_from_type(Type interface_to_get)
    {
        if(masters.ContainsKey(interface_to_get))
        {
            return masters[interface_to_get];
        }

        return null;
    }

    private void finishLoading(bool loading = false)
    {
        #region Create Missing Objects
        GameObject mapRootGo = new GameObject("Map");
        Transform mapRoot = mapRootGo.transform;
        floorsParent = new GameObject("Floors");
        floorsParent.transform.parent = mapRoot;
        wallsParent = new GameObject("Walls");
        wallsParent.transform.parent = mapRoot;
        othersParent = new GameObject("Others");
        othersParent.transform.parent = mapRoot;
        fogParent = new GameObject("Fog");
        fogParent.transform.parent = mapRoot;
        
        GameObject stat_bar_go = ((ModalMaster)modal_master).get_instance_go(MODAL.STATS);
        stats_bar = stat_bar_go.GetComponent<StatBar>();
        masters.Add(typeof(IStatsBar), stats_bar);
        ((Modal)stats_bar).open(); //This will initialize it
        #endregion
        
        if(!loading)
        {
            //Not loading, prepare a new seed
            floorSeeds.Add(rng.Next());
        }
        floorRng = new System.Random(floorSeed);
        go_to_floor(floorNum, PLACE_PLAYER_AT_RANDOM.IF_NEW);
        
        if(loading) { player.load(); }
        else { player.finish_loading(); }
        PlayerHealthMaster.init(); //Reload player stats and fetch actual instances

        movePlayerAndCamera(player.position); //Otherwise the camera will slowly move over to start position instead
    }

    public void new_game()
    {
        finishLoading(false);
    }

    public void save_game(int save_num)
    {
        SaveMaster.instance.save(save_num);
        message_master.set_message("Game Saved");
    }

    public void load_game(int save_num)
    {
        SaveMaster.instance.load(save_num);
        Savable.load(this);
        finishLoading(true);
        message_master.set_message("Game Loaded");
    }

    public bool random_encounter()
    {
        int v = rng.Next(0, 100); //Random number [0-99) (which is 100 values)

        //v = 0; //Force encounters on
        //v = 100; //Force encounters off

        //if(v <= 0) //1% chance of true
        if(v <= 11) //12% chance of true (default)
        {
            int enemyCount = UnityEngine.Random.Range(1, 4);

            List<ICombatant> enemies = new List<ICombatant>();
            foreach (int i in Enumerable.Range(0, enemyCount))
            {
                enemies.Add(new TestEnemy());
            }
            
            combat_master.start_battle(new List<IPlayable>() { player }, enemies);
            return true;
        }
        //else if(v <= 22)
        //{
        //    switch_dialog(Menus.info, "This is a test dialog.\nAnd more text here.\nAnother line!");
        //}
        return false;
    }

    #region Teleport
    public void movePlayerAndCamera(Vector2Int p)
    {
        player.set_position(p);
        //main_camera_go.transform.position = new Vector3(p.x, p.y, main_camera_go.transform.position.z);
        camera_master.attach();
        clearFogAroundSpot(player.position, player.VIEW_MAX);
    }

    private void placePlayerRandomly()
    {
        Vector2Int newPos = new Vector2Int(-1, -1);
        int w = staticMap.width;
        int h = staticMap.height;
        
        while(!freeSpot(newPos))
        {
            newPos = new Vector2Int(
                rng.Next(0, w),
                rng.Next(0, h)
                );
        }
        movePlayerAndCamera(newPos);
    }

    private void placePlayerAtStairsUp()
    {
        movePlayerAndCamera(stairsUp);
    }

    private void placePlayerAtStairsDown()
    {
        movePlayerAndCamera(stairsDown);
    }
    #endregion

    #region Move Logic
    public bool freeSpot(Vector2Int p)
    {
        return freeSpot(p.x, p.y);
    }

    public bool freeSpot(int x, int y)
    {
        if(x < 0 || x >= staticMap.width || y < 0 || y >= staticMap.height) { return false; }

        Tile at = staticMap[x, y];
        if(at != null)
        {
            if(at.type == Tile.TILE_TYPE.WALL) { return false; }
        }

        return true;
    }

    public void go_up_a_floor()
    {
        go_to_floor(floorNum - 1, PLACE_PLAYER_AT_RANDOM.NO);
        placePlayerAtStairsDown();
    }

    public void go_down_a_floor()
    {
        go_to_floor(floorNum + 1, PLACE_PLAYER_AT_RANDOM.NO);
        placePlayerAtStairsUp();
    }

    public void go_to_floor(int floorNum, PLACE_PLAYER_AT_RANDOM placePlayerAtRandom = PLACE_PLAYER_AT_RANDOM.YES)
    {
        #region Unload current floor
        //Only works if not-loading
        if(staticMaps.Count > this.floorNum)
        {
            for(int x = 0; x < staticMap.width; x++)
            {
                for(int y = 0; y < staticMap.height; y++)
                {
                    Tile tile = staticMap[x, y];
                    GameObject go = tile.gameObject;
                    Destroy(go);
                    tile.gameObject = null;
                }
            }
        }
        if(fogMaps.Count > this.floorNum)
        {
            for(int x = 0; x < fogMap.width; x++)
            {
                for(int y = 0; y < fogMap.height; y++)
                {
                    Tile tile = fogMap[x, y];
                    if(tile != null)
                    {
                        if(tile.gameObject != null)
                        {
                            Destroy(tile.gameObject);
                        }
                        tile.gameObject = null;
                    }
                }
            }
        }

        //For loading
        foreach(Transform child in floorsParent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in wallsParent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in othersParent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in fogParent.transform)
        {
            Destroy(child.gameObject);
        }
        //TODO Make it so I don't have to do both for loading and not loading every time
        #endregion
        this.floorNum = floorNum;

        bool newFloor = false;
        //Generate any missing floors
        while(floorSeeds.Count - 1 < floorNum)
        {
            //Debug.Log($"{floorSeeds.Count} floors found but looking for floor {floorNum}. Generating.");
            floorRng = new System.Random(floorSeeds[floorNum -1]);
            floorSeeds.Add(floorRng.Next());
        }
        floorRng = new System.Random(floorSeed);

        if(staticMaps.Count > floorNum)
        {
            //Already exists
            initializeMoveMap(staticMap);
            initializeMoveMap(fogMap);
        }
        else
        {
            newFloor = true;
            DungeonGenerator.init(seed: floorSeed, allowTouching: false, mapWidth: MAP_WIDTH, mapHeight: MAP_HEIGHT);
            DungeonGenerator.DUNGEON_TYPE[] dungeon_types = (DungeonGenerator.DUNGEON_TYPE[])Enum.GetValues(typeof(DungeonGenerator.DUNGEON_TYPE));
            DungeonGenerator.DUNGEON_TYPE dungeon_type = (DungeonGenerator.DUNGEON_TYPE)dungeon_types.GetValue(rng.Next(dungeon_types.Length));
            DungeonGenerator.SPAWN_TILES tiles_to_spawn = DungeonGenerator.SPAWN_TILES.STAIRS_DOWN;
            if(floorNum > 0)
            {
                tiles_to_spawn |= DungeonGenerator.SPAWN_TILES.STAIRS_UP;
            }
            Tile[,] generated = DungeonGenerator.generate(dungeon_type, tiles_to_spawn);
            staticMaps.Add(createMap(generated));
            fogMaps.Add(createFogMap(generated));
        }

        stairsUp = new Vector2Int(-1, -1);
        stairsDown = new Vector2Int(-1, -1);
        for(int x = 0; x < staticMap.width; x++)
        {
            for(int y = 0; y < staticMap.height; y++)
            {
                Tile tile = staticMap[x, y];
                if(tile.type == Tile.TILE_TYPE.STAIRS_UP)
                {
                    stairsUp = new Vector2Int(x, y);
                }
                else if(tile.type == Tile.TILE_TYPE.STAIRS_DOWN)
                {
                    stairsDown = new Vector2Int(x, y);
                }
            }
        }
        
        if(placePlayerAtRandom == PLACE_PLAYER_AT_RANDOM.YES || (newFloor && placePlayerAtRandom == PLACE_PLAYER_AT_RANDOM.IF_NEW))
        {
            placePlayerRandomly();
        }
    }
    #endregion

    #region MoveMap Utilities
    private MoveMap<Tile> createMap(Scripts.Tile[,] inMap)
    {
        int w = inMap.GetLength(0);
        int h = inMap.GetLength(1);
        MoveMap<Tile> ret = new MoveMap<Tile>(w, h);

        for(int x = 0; x < w; x++)
        {
            for(int y = 0; y < h; y++)
            {
                ret[x, y] = inMap[x, y];
                createInstanceForTile(ret[x, y], x, y);
            }
        }

        return ret;
    }

    private MoveMap<Tile> createFogMap(Scripts.Tile[,] inMap)
    {
        int w = inMap.GetLength(0);
        int h = inMap.GetLength(1);
        MoveMap<Tile> ret = new MoveMap<Tile>(w, h);

        for(int x = 0; x < w; x++)
        {
            for(int y = 0; y < h; y++)
            {
                if(inMap[x, y].type != Tile.TILE_TYPE.WALL)
                {
                    ret[x, y] = new Tile(Tile.TILE_TYPE.FOG);
                    createInstanceForTile(ret[x, y], x, y);
                }
            }
        }

        return ret;
    }

    private MoveMap<Tile> initializeMoveMap(MoveMap<Tile> inMap)
    {
        for(int x = 0; x < inMap.width; x++)
        {
            for(int y = 0; y < inMap.height; y++)
            {
                if(inMap[x, y] != null && inMap[x, y].gameObject == null)
                {
                    createInstanceForTile(inMap[x, y], x, y);
                }
            }
        }
        return inMap;
    }

    private GameObject createInstanceForTile(Tile tile, int x, int y)
    {
        GameObject prefab = null;
        GameObject parent = null;
        switch(tile.type)
        {
            case Tile.TILE_TYPE.FLOOR:
                prefab = prefabFloorTile;
                parent = floorsParent;
                break;
            case Tile.TILE_TYPE.WALL:
                prefab = prefabWall;
                parent = wallsParent;
                break;
            case Tile.TILE_TYPE.STAIRS_UP:
                prefab = prefabStairsUp;
                parent = othersParent;
                break;
            case Tile.TILE_TYPE.STAIRS_DOWN:
                prefab = prefabStairsDown;
                parent = othersParent;
                break;
            case Tile.TILE_TYPE.FOG:
                prefab = prefabFog;
                parent = fogParent;
                break;
            default:
                Console.WriteLine("ERROR: createInstanceForTile found Tile of unhandled type");
                break;
        }
        tile.gameObject = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
        tile.gameObject.transform.SetParent(parent.transform);
        return tile.gameObject;
    }
    #endregion

    //TODO Fix being able to "see through" 1 wide walls
    public void clearFogAroundSpot(Vector2Int pos, float distance)
    {
        for(int offset = 0; offset <= distance; offset++)
        {
            for(int x = pos.x - offset; x <= pos.x + offset && x < fogMap.width; x++)
            {
                if(x < 0) { continue; }
                for(int y = pos.y - offset; y <= pos.y + offset && y < fogMap.height; y++)
                {
                    if(y < 0) { continue; }
                    if(Vector2Int.Distance(pos, new Vector2Int(x, y)) <= distance)
                    {
                        Tile to_remove = fogMap[x, y];
                        if(to_remove?.gameObject != null)
                        {
                            Destroy(to_remove.gameObject);
                        }
                        fogMap[x, y] = null;
                    }
                }
            }
        }
    }
}
