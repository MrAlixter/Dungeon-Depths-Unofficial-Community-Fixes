using Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class ModalMaster : ScriptableObject, IModalMaster
{
    private static ModalMaster _instance;
    public static ModalMaster instance { get { if(_instance == null) { _instance = CreateInstance<ModalMaster>(); } return _instance; } }

    private static char SEP = Path.DirectorySeparatorChar;
    private static string MODAL_PREFAB_DIR = "Prefabs" + SEP + "UI" + SEP + "Modals";
    private static readonly Dictionary<MODAL, string> MODAL_PREFAB_NAMES = new Dictionary<MODAL, string>()
    {
        { MODAL.MAIN, "Main Menu Modal" },
        { MODAL.CHARACTER_CREATION, "Character Creation Menu Modal" },
        { MODAL.DUNGEON_GENERATOR_SETTINGS, "Dungeon Generation Settings Menu Modal" },
        { MODAL.COMBAT, "Battle Modal" },
        { MODAL.PAUSE, "Pause Menu Modal" },
        { MODAL.STATS, "Stats Bar" },
        { MODAL.INFO, "Info Modal" },
        { MODAL.CHARACTER, "Character Menu Modal" },
        { MODAL.EQUIPMENT, "Equipment Menu Modal" },
        { MODAL.ITEMS, "Items Menu Modal" }
    };
    private static readonly Dictionary<Type, MODAL> MODAL_IMPLEMENTATIONS = new Dictionary<Type, MODAL>()
    {
        { typeof(IEquipmentModal), MODAL.EQUIPMENT },
        { typeof(ICombatModal), MODAL.COMBAT }
    };
    private static Dictionary<MODAL, GameObject> prefabs;
    private static Dictionary<MODAL, GameObject> instances;

    private GameObject current_modals_go;
    
    public MODAL current_modal { get; internal set; }
    //private Modal modal { get { return current_modal == MODAL.NONE ? null : modals[current_modal]; } }
    public MODE current_mode { get; internal set; }

    public void Awake()
    {
        prefabs = new Dictionary<MODAL, GameObject>();
        instances = new Dictionary<MODAL, GameObject>();

        current_modals_go = new GameObject("Current Modals");

        load_all_prefabs();
    }
    public static ModalMaster init(MODAL current_modal, MODE current_mode)
    {
        instance.current_modal = current_modal;
        instance.current_mode = current_mode;

        load_all_prefabs();

        return instance;
    }
    protected static void load_all_prefabs()
    {
        foreach(KeyValuePair<MODAL, string> modal in MODAL_PREFAB_NAMES)
        {
            if(!prefabs.ContainsKey(modal.Key))
            {
                prefabs.Add(modal.Key, Resources.Load<GameObject>(get_prefab(modal.Key)));
            }
        }
    }
    public GameObject get_instance_go(MODAL modal)
    {
        if(!instances.ContainsKey(modal) || instances[modal] == null)
        {
            GameObject go = Instantiate(prefabs[modal], current_modals_go.transform);
            instances[modal] = go;
        }
        return instances[modal];
    }
    public Modal get_instance(MODAL modal) { return get_instance_go(modal).GetComponent<Modal>(); }
    public T get_interfaced_modal<T>()
    {
        MODAL implementing_modal = MODAL_IMPLEMENTATIONS[typeof(T)];
        if(instances.ContainsKey(implementing_modal))
        {
            return instances[implementing_modal].GetComponent<T>();
        }
        return default(T);
    }
    private static string get_prefab(MODAL modal)
    {
        return MODAL_PREFAB_DIR + SEP + MODAL_PREFAB_NAMES[modal];
    }
    private static GameObject get_modal(MODAL modal)
    {
        if(instances.ContainsKey(modal) && instances[modal]) { return instances[modal]; } 
        return null;
    }

    private void switch_modal(MODAL modal)
    {
        if(instances.ContainsKey(current_modal))
        {
            GameObject current = instances[current_modal];
            if(current != null)
            {
                Destroy(current);
            }
            instances.Remove(current_modal);
        }

        if(modal == MODAL.NONE)
        {
            current_mode = MODE.MOVEMENT;
            to_player_mode();
        }
        else
        {
            GameObject next = get_instance_go(modal);
            Modal next_modal = next.GetComponent<Modal>();
            next_modal.open(); //Does modal initailization, mostly selecting buttons for naviation
            current_mode = modal == MODAL.COMBAT ? MODE.COMBAT : MODE.DIALOG;
            to_UI_mode();
        }

        current_modal = modal;
    }
    public void try_switch_modal(MODAL modal)
    {
        if(is_modal_allowed_to_switch(modal))
        {
            switch_modal(modal);
        }
    }
    public void force_switch_modal(MODAL modal)
    {
        //Warningless force switches:
        //These modals lock you in and can only leave by very specific means. 
        //Those means will call force_switch
        if(current_modal == MODAL.COMBAT && modal == MODAL.NONE) { }
        else if(current_modal == MODAL.MAIN && modal == MODAL.NONE) { }
        else if(current_modal == MODAL.DUNGEON_GENERATOR_SETTINGS && modal == MODAL.NONE) { }
        else
        {
            UnityEngine.Debug.LogWarning($"Unauthorized use of force_switch_modal({Enum.GetName(typeof(MODAL), modal)}) called. {new StackTrace().GetFrame(1)}");
        }
        switch_modal(modal);
    }
    
    public bool is_in_combat { get { return current_mode == MODE.COMBAT; } }
    public bool is_in_dialog { get { return current_mode == MODE.DIALOG; } }
    public bool is_in_movement { get { return current_mode == MODE.MOVEMENT; } }

    public bool is_modal_allowed_to_open_over(MODAL modal)
    {
        if(current_modal == MODAL.ITEMS && modal == MODAL.INFO) { return true; }
        return false;
    }
    public bool is_modal_allowed_to_switch(MODAL modal)
    {
        if(current_mode == MODE.COMBAT) { return false; }
        else if(current_mode == MODE.DIALOG)
        {
            if(current_modal == MODAL.MAIN)
            {
                return modal == MODAL.CHARACTER_CREATION;
            }
            else if(current_modal == MODAL.CHARACTER_CREATION)
            {
                return modal == MODAL.MAIN || modal == MODAL.DUNGEON_GENERATOR_SETTINGS;
            }
            else if(current_modal == MODAL.DUNGEON_GENERATOR_SETTINGS)
            {
                return modal == MODAL.CHARACTER_CREATION;
            }
            else if(current_modal == MODAL.PAUSE)
            {
                //        Save message
                return modal == MODAL.INFO || modal == MODAL.NONE;
            }
            else if(current_modal == MODAL.INFO)
            {
                return modal == MODAL.NONE;
            }
            else if(current_modal == MODAL.CHARACTER)
            {
                return modal == MODAL.NONE || modal == MODAL.EQUIPMENT || modal == MODAL.ITEMS || modal == MODAL.STATS;
            }
            else if(current_modal == MODAL.EQUIPMENT)
            {
                return modal == MODAL.NONE;
            }
            else if(current_modal == MODAL.ITEMS)
            {
                return modal == MODAL.NONE;
            }
            else if(current_modal == MODAL.STATS)
            {
                return modal == MODAL.NONE;
            }
        }
        else if(current_mode == MODE.MOVEMENT)
        {
            return current_modal == MODAL.NONE;
        }
        return false;
    }
    public bool is_modal_open(MODAL modal)
    {
        return instances.ContainsKey(modal) && instances[modal] != null;
    }

    private void open_modal(MODAL modal)
    {
        if(modal == MODAL.NONE)
        {
            throw new System.Exception("Cannot open_modal MODAL.NONE");
        }
        else
        {
            GameObject next = get_instance_go(modal);
            current_mode = modal == MODAL.COMBAT ? MODE.COMBAT : MODE.DIALOG;
            to_UI_mode();
        }

        current_modal = modal;
    }
    public void try_open_modal(MODAL modal)
    {
        if(is_modal_allowed_to_open_over(modal))
        {
            open_modal(modal);
        }
    }
    public void force_open_modal(MODAL modal)
    {
        UnityEngine.Debug.LogError($"force_open_modal({Enum.GetName(typeof(MODAL), modal)}) called. {new StackTrace().GetFrame(1)}");
        force_open_modal(modal);
    }

    public void try_open_message_modal(string message, bool overwrite = true)
    {
        try_open_modal(MODAL.INFO);
        GameObject go = get_modal(MODAL.INFO);
        if(go)
        {
            InfoModal im = go.GetComponent<InfoModal>();
            if(overwrite)
            {
                im.set_text(message);
            }
            else
            {
                im.append_text(message);
            }
        }
    }
    public void try_switch_message_modal(string message, bool overwrite = true)
    {
        try_switch_modal(MODAL.INFO);
        GameObject go = get_modal(MODAL.INFO);
        if(go)
        {
            InfoModal im = go.GetComponent<InfoModal>();
            if(overwrite)
            {
                im.set_text(message);
            }
            else
            {
                im.append_text(message);
            }
        }
    }

    private void to_UI_mode()
    {
        Player.input.UI.Enable();
        Player.input.Player.Disable();
    }
    private void to_player_mode()
    {
        Player.input.UI.Disable();
        Player.input.Player.Enable();
    }


    //public bool is_modal_none_open { get { return current_modal == MODAL.NONE; } }
    //public bool is_no_modal_open { get { return is_modal_none_open; } }
    //public bool is_modal_battle_open { get { return current_modal == MODAL.BATTLE; } }
    //public bool is_modal_info_open { get { return current_modal == MODAL.INFO; } }
    //public bool is_modal_pause_open { get { return current_modal == MODAL.PAUSE; } }
    //public bool is_modal_character_open { get { return current_modal == MODAL.CHARACTER; } }
    //public bool is_modal_equipment_open { get { return current_modal == MODAL.EQUIPMENT; } }
    //public bool is_modal_items_open { get { return current_modal == MODAL.ITEMS; } }
    //public bool is_modal_main_open { get { return current_modal == MODAL.MAIN; } }


    //public void update_battle_bars()
    //{
    //    //TODO 
    //}

    //public void end_battle()
    //{
    //    current_mode = MODE.MOVEMENT;
    //    switch_modal(MODAL.NONE);
    //}

    //public void end_combat_dialog(string message)
    //{
    //    //Because combat has exceptions to disallow switching off,
    //    //this special method exists to break out of combat
    //    current_mode = MODE.DIALOG;
    //    switch_modal(MODAL.INFO, message);
    //}

    //public void leave_main_menu()
    //{
    //    current_mode = MODE.MOVEMENT;
    //    switch_modal(MODAL.NONE);
    //}

    //public void switch_modal(MODAL modal)
    //{
    //    if(this.modal?.closable == false)
    //    {
    //        if(current_modal == MODAL.BATTLE && is_in_combat) { return; }
    //        if(current_modal == MODAL.MAIN && is_in_dialog) { return; }
    //    }

    //    if(current_modal != MODAL.NONE)
    //    {
    //        close_modal(current_modal);
    //    }

    //    if(modal == MODAL.NONE)
    //    {
    //        current_mode = MODE.MOVEMENT;
    //        if(current_modal == MODAL.NONE)
    //        {
    //            current_mode = MODE.MOVEMENT;
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        open_modal(modal);
    //    }
    //}

    //public void switch_modal(MODAL modal, string message)
    //{
    //    switch_modal(modal);

    //    if(modal == MODAL.INFO)
    //    {
    //        set_info_dialog_text(message);
    //    }
    //}

    //public void close_modal(MODAL modal)
    //{
    //    if(current_mode == MODE.COMBAT) { return; }

    //    switch(modal)
    //    {
    //        case MODAL.BATTLE:
    //            close_modal_battle();
    //            break;
    //        case MODAL.CHARACTER:
    //            close_modal_character();
    //            break;
    //        case MODAL.EQUIPMENT:
    //            close_modal_equipment();
    //            break;
    //        case MODAL.INFO:
    //            close_modal_info();
    //            break;
    //        case MODAL.PAUSE:
    //            close_modal_pause();
    //            break;
    //        case MODAL.ITEMS:
    //            close_modal_items();
    //            break;
    //        case MODAL.MAIN:
    //            close_modal_main();
    //            break;
    //    }

    //    if(battle_modal.active) { current_modal = MODAL.BATTLE; }
    //    else if(character_modal.active) { current_modal = MODAL.CHARACTER; }
    //    else if(equipment_modal.active) { current_modal = MODAL.EQUIPMENT; }
    //    else if(info_modal.active) { current_modal = MODAL.INFO; }
    //    else if(pause_modal.active) { current_modal = MODAL.PAUSE; }
    //    else if(items_modal.active) { current_modal = MODAL.ITEMS; }
    //    else if(main_modal.active) { current_modal = MODAL.MAIN; }
    //    else { current_modal = MODAL.NONE; }

    //    if(current_modal == MODAL.NONE)
    //    {
    //        current_mode = MODE.MOVEMENT;
    //    }
    //}

    //public void open_modal(MODAL modal)
    //{
    //    if(current_mode == MODE.COMBAT) { return; }

    //    current_modal = modal;
    //    current_mode = MODE.DIALOG;
    //    switch(modal)
    //    {
    //        case MODAL.BATTLE:
    //            current_mode = MODE.COMBAT;
    //            open_modal_battle();
    //            return;
    //        case MODAL.CHARACTER:
    //            open_modal_character();
    //            return;
    //        case MODAL.EQUIPMENT:
    //            open_modal_equipment();
    //            return;
    //        case MODAL.INFO:
    //            open_modal_info();
    //            return;
    //        case MODAL.PAUSE:
    //            open_modal_pause();
    //            return;
    //        case MODAL.ITEMS:
    //            open_modal_items();
    //            return;
    //        case MODAL.MAIN:
    //            open_modal_main();
    //            return;
    //    }
    //}

    //public void open_modal(MODAL modal, string text)
    //{
    //    open_modal(modal);
    //    set_info_dialog_text(text);
    //}

    //#region Battle Dialog Controls
    //private void open_modal_battle()
    //{
    //    battle_modal.Awake(); //Do any initialization necessary before loading
    //    //BattleMaster battle_master = battle_modal.gameObject.AddComponent<BattleMaster>();
    //    //battle_master.init(this, this, this, allies, enemies);
    //    //battle_master.startBattle();

    //    //battle_modal.set_target(enemy);

    //    //battle_modal.set_player_name_text(player.player_name);
    //    //battle_modal.update_player_health(player.HP, player.MAX_HP);

    //    //battle_modal.set_enemy_name_text(enemy.enemy_name);
    //    //battle_modal.update_enemy_health(enemy.HP, enemy.MAX_HP);

    //    //battle_modal.update_turn(turn);
    //    //battle_modal.set_battle_information("");

    //    //battle_modal.update_stats();

    //    //player_turn = true;
    //    battle_modal.open();
    //}

    //private void close_modal_battle()
    //{
    //    //////////Destroy(battle_master);

    //    battle_modal.close();
    //}
    //#endregion

    //#region Info Dialog Controls
    //private void open_modal_info()
    //{
    //    info_modal.Awake();

    //    info_modal.open();
    //}

    //private void open_modal_info(string info)
    //{
    //    info_modal.Awake();

    //    info_modal.set_text(info);
    //    info_modal.open();
    //}

    //private void close_modal_info()
    //{
    //    info_modal.close();
    //}

    //private void set_info_dialog_text(string info)
    //{
    //    info_modal.set_text(info);
    //}
    //#endregion

    //#region Pause Dialog Controls
    //private void open_modal_pause()
    //{
    //    pause_modal.Awake();
    //    pause_modal.open();
    //}

    //private void close_modal_pause()
    //{
    //    pause_modal.close();
    //}
    //#endregion

    //#region Character Dialog Controls
    //private void open_modal_character()
    //{
    //    character_modal.open();
    //}

    //private void close_modal_character()
    //{
    //    character_modal.close();
    //}
    //#endregion

    //#region Equipment Dialog Controls
    //private void open_modal_equipment()
    //{
    //    equipment_modal.Awake();

    //    equipment_modal.load_armor_choices();
    //    equipment_modal.load_current_equipment();

    //    equipment_modal.open();
    //}

    //private void close_modal_equipment()
    //{
    //    equipment_modal.close();
    //}
    //#endregion

    //#region Items Dialog Controls
    //private void open_modal_items()
    //{
    //    //Unneccessary because it's now called in the Awake(), which is 
    //    //automatically called every time the object is set ot active
    //    items_modal.open();
    //}

    //private void close_modal_items()
    //{
    //    items_modal.close();
    //}
    //#endregion

    //#region Main Dialog Controls
    //private void open_modal_main()
    //{
    //    main_modal.open();
    //}

    //private void close_modal_main()
    //{
    //    main_modal.close();
    //}
    //#endregion
}
