using Assets.Scripts;
using Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


public sealed class Master : MonoBehaviour, IMessageMaster
{
    private static Master _instance;
    public static Master instance { get { if(_instance != null) { return _instance; } else { _instance = new Master(); return _instance; } } }

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

    [SerializeField]
    private Controller controller;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject playerCameraObj;
    [SerializeField]
    private PlayerCamera playerCamera;
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private GameObject floorsParent;
    [SerializeField]
    private GameObject wallsParent;
    
    [SerializeField]
    private PlayerHealthMaster playerHealthMaster;
    [SerializeField]
    private IModalMaster modalMaster;
    [SerializeField]
    private ITurnMaster turnMaster;
    [SerializeField]
    private ICombatMaster combatMaster;

    [SerializeField]
    private IProfilePictureMaster profilePictureMaster;
    
    // Use this for initialization
    void Awake()
    //void Start()
	{
        //Set them to get the compiler warnings to shut up 
        //Specifically to -1 to make the game crash immediately if they're not set
        if(MAP_WIDTH == 0) { MAP_WIDTH = -1; }
        if(MAP_HEIGHT == 0) { MAP_HEIGHT = -1; }

        floorsParent = GameObject.Find("Floors");
        wallsParent = GameObject.Find("Walls");
        System.Random r = new System.Random();
        DungeonGenerator.init(seed: r.Next(), allowTouching: false, mapWidth: MAP_WIDTH, mapHeight: MAP_HEIGHT);
        DungeonGenerator.DUNGEON_TYPE[] dungeon_types = (DungeonGenerator.DUNGEON_TYPE[])Enum.GetValues(typeof(DungeonGenerator.DUNGEON_TYPE));
        Tile[,] generated = DungeonGenerator.generate( (DungeonGenerator.DUNGEON_TYPE)dungeon_types.GetValue(r.Next(dungeon_types.Length)) );
        

        staticMap = createMap(generated);
        entityMap = new MoveMap<GameObject>(staticMap.width, staticMap.height);

        //UnityEngine.Random.InitState(0); //Init seed to 0 for consistent testing
        
        turnMaster = TurnMaster.init(1);//, true);

        player = Player.init();
        controller = Controller.instance;
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        playerCameraObj = GameObject.Find("Main Camera");
        playerCamera = playerCameraObj.GetComponent<PlayerCamera>();
        profilePictureMaster = ProfilePicture.init(player);
        player.Awake();
        placePlayer();
        

        //Because there are health bars in the battle canvas 
        //I cannot make the health bar a singleton.
        //Thus, I must search for it at Start
        StatBar stats_bar = GameObject.Find("Stats Canvas").GetComponent<StatBar>();
        modalMaster = ModalMaster.init(player, MODAL.none, MODE.movement, stats_bar, BattleModalV2.instance, InfoModal.instance, PauseModal.instance, CharacterModal.instance, EquipmentModal.instance, ItemsModal.instance);

       
        playerHealthMaster = PlayerHealthMaster.init(modalMaster, stats_bar, player);
        BattleMaster.init(this, modalMaster, playerHealthMaster, turnMaster);
    }

    // Update is called once per frame
    void Update () {
        if (controller.pause_menu.down)
        {
            if(modalMaster.is_in_movement && modalMaster.is_no_modal_open)
            {
                modalMaster.switch_modal(MODAL.pause);
            }
            else
            {
                //Close any dialog (switch_dialog() is smart enough 
                //to prevent the battle menu from being closed
                //while in battle)
                modalMaster.switch_modal(MODAL.none);
            }
        }
        if (controller.character_menu.down)
        {
            if (modalMaster.current_modal == MODAL.none && !modalMaster.is_modal_character_open)
            {
                modalMaster.switch_modal(MODAL.character);
            }
            else
            {
                //Close any dialog (switch_dialog() is smart enough 
                //to prevent the battle menu from being closed
                //while in battle)
                modalMaster.switch_modal(MODAL.none);
            }
        }

        if(modalMaster.is_in_movement)
        {
            if(controller.zoom.hold)
            {
                float zoom = controller.zoom.magnitude;
                zoom = -1 * Mathf.Sign(zoom) * Mathf.Clamp(Mathf.Abs(zoom / 100), 1, float.MaxValue);
                playerCamera.cameraHeight += zoom;
                if(playerCamera.cameraHeight <= 0)
                {
                    playerCamera.cameraHeight = 1;
                }
            }
            if(controller.moveU.down || controller.moveR.down || controller.moveD.down || controller.moveL.down)
            {
                playerCamera.attached = true;
                //Teleport instantly
                Vector3 pPos = player.transform.position;
                Vector3 cPos = playerCamera.transform.position;
                playerCamera.transform.position = new Vector3(pPos.x, pPos.y, cPos.z);
            }
            else if(controller.panHorizontally.hold || controller.panVertically.hold || controller.mouse_panHorizontally.hold || controller.mouse_panVertically.hold)
            {
                playerCamera.attached = false;
                Vector3 pos = playerCamera.transform.position;
                float sensitivity = 0.01f * (-1 * pos.z);
                float amountX;
                float amountY;
                if(controller.panHorizontally.hold)
                {
                    amountX = controller.panHorizontally.magnitude * sensitivity;
                }
                else
                {
                    amountX = controller.mouse_panHorizontally.magnitude * sensitivity;
                }
                if(controller.panVertically.hold)
                {
                    amountY = controller.panVertically.magnitude * sensitivity;
                }
                else
                {
                    amountY = controller.mouse_panVertically.magnitude * sensitivity;
                }
                pos = new Vector3(pos.x + amountX, pos.y + amountY, pos.z);
                playerCamera.transform.position = pos;
            }
        }
    }

    public bool random_encounter()
    {
        float v = UnityEngine.Random.value * 100; //Random number on a scale of 0-100 inclusive

        v = 0; //Force encounters on
        //v = 100; //Force encounters off
        
        //if(v <= 0) //1/101% chance of true
        if(v <= 11) //12/101% chance of true (default)
        {
            int enemyCount = UnityEngine.Random.Range(1, 4);

            List<ICombatant> enemies = new List<ICombatant>();
            foreach (int i in Enumerable.Range(0, enemyCount))
            {
                enemies.Add(new TestEnemy());
            }

            combatMaster = BattleMaster.createInstance(gameObject);
            combatMaster.startBattle(new List<IPlayable>() { player }, enemies);
            //TODO DESTROY COMBAT MASTER
            return true;
        }
        //else if(v <= 22)
        //{
        //    switch_dialog(Menus.info, "This is a test dialog.\nAnd more text here.\nAnother line!");
        //}
        return false;
    }

    ////TODO Move these to a difference class
    public void display_message(string message)
    {
        if(modalMaster.is_in_combat)
        {
            //battle_menu.add_battle_information(message);
            ////////battle_master.add_battle_information(message); //TODO
        }
        else
        {
            //open_info_dialog(message);
            modalMaster.switch_modal(MODAL.info, message); //TODO? 
        }
    }

    public void set_message(string message)
    {
        if(modalMaster.is_in_combat)
        {
            //battle_menu.set_battle_information(message);
            ////////battle_master.set_battle_information(message); //TODO
        }
        else
        {
            //open_info_dialog(message);
            modalMaster.switch_modal(MODAL.info, message); //TODO?
        }
    }
    //END TODO

    private void movePlayerAndCamera(Vector2Int p)
    {
        player.setPosition(p);
        playerCameraObj.transform.position = new Vector3(p.x, p.y, playerCameraObj.transform.position.z);
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

    #region Move Logic
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
    #endregion

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
