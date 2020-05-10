using Scripts;
using UnityEngine;

public class ModalMaster : IModalMaster
{
    private static ModalMaster _instance;
    public static ModalMaster instance { get { if(_instance != null) { return _instance; } else { _instance = new ModalMaster(); return _instance; } } }

    public static ModalMaster init(Player player, MODAL current_modal, MODE current_mode, StatBar stats_bar, BattleModalV2 battle_modal, InfoModal info_modal, PauseModal pause_modal, CharacterModal character_modal, EquipmentModal equipment_modal, ItemsModal items_modal)
    {
        instance.player = player;
        instance.current_modal = current_modal;
        instance.current_mode = current_mode;

        instance.stats_bar = stats_bar;
        instance.battle_modal = battle_modal;
        instance.info_modal = info_modal;
        instance.pause_modal = pause_modal;
        instance.character_modal = character_modal;
        instance.equipment_modal = equipment_modal;
        instance.items_modal = items_modal; 

        return instance;
    }

    [SerializeField]
    private Player player;
    [SerializeField]
    public MODAL current_modal { get; internal set; }
    [SerializeField]
    public MODE current_mode { get; internal set; }


    [SerializeField]
    private StatBar stats_bar;
    //////////[SerializeField]
    //////////private BattleMaster battle_master;
    [SerializeField]
    private BattleModalV2 battle_modal;
    [SerializeField]
    private InfoModal info_modal;
    [SerializeField]
    private PauseModal pause_modal;
    [SerializeField]
    private CharacterModal character_modal;
    [SerializeField]
    private EquipmentModal equipment_modal;
    [SerializeField]
    private ItemsModal items_modal;
    

    public bool is_in_combat { get { return current_mode == MODE.combat; } }
    public bool is_in_dialog { get { return current_mode == MODE.dialog; } }
    public bool is_in_movement { get { return current_mode == MODE.movement; } }
    
    public bool is_modal_none_open { get { return current_modal == MODAL.none; } }
    public bool is_no_modal_open { get { return is_modal_none_open; } }
    public bool is_modal_battle_open { get { return current_modal == MODAL.battle; } }
    public bool is_modal_info_open { get { return current_modal == MODAL.info; } }
    public bool is_modal_pause_open { get { return current_modal == MODAL.pause; } }
    public bool is_modal_character_open { get { return current_modal == MODAL.character; } }
    public bool is_modal_equipment_open { get { return current_modal == MODAL.equipment; } }
    public bool is_modal_items_open { get { return current_modal == MODAL.items; } }

    

    public void update_battle_bars()
    {
        //TODO 
    }

    public void end_battle()
    {
        current_mode = MODE.movement;
        switch_modal(MODAL.none);
    }

    public void end_combat_dialog(string message)
    {
        //Because combat has exceptions to disallow switching off,
        //this special method exists to break out of combat
        current_mode = MODE.dialog;
        switch_modal(MODAL.info, message);
    }

    public void switch_modal(MODAL modal)
    {
        if(current_mode == MODE.combat) { return; }

        if(current_modal != MODAL.none)
        {
            close_modal(current_modal);
        }

        if(modal == MODAL.none)
        {
            current_mode = MODE.movement;
            if(current_modal == MODAL.none)
            {
                current_mode = MODE.movement;
                return;
            }
        }
        else
        {
            open_modal(modal);
        }
    }

    public void switch_modal(MODAL modal, string message)
    {
        switch_modal(modal);

        if(modal == MODAL.info)
        {
            set_info_dialog_text(message);
        }
    }

    public void close_modal(MODAL modal)
    {
        if(current_mode == MODE.combat) { return; }

        switch(modal)
        {
            case MODAL.battle:
                close_modal_battle();
                break;
            case MODAL.character:
                close_character_dialog();
                break;
            case MODAL.equipment:
                close_equipment_dialog();
                break;
            case MODAL.info:
                close_info_dialog();
                break;
            case MODAL.pause:
                close_pause_dialog();
                break;
            case MODAL.items:
                close_items_dialog();
                break;
        }

        if(battle_modal.active) { current_modal = MODAL.battle; }
        else if(character_modal.active) { current_modal = MODAL.character; }
        else if(equipment_modal.active) { current_modal = MODAL.equipment; }
        else if(info_modal.active) { current_modal = MODAL.info; }
        else if(pause_modal.active) { current_modal = MODAL.pause; }
        else if(items_modal.active) { current_modal = MODAL.items; }
        else { current_modal = MODAL.none; }

        if(current_modal == MODAL.none)
        {
            current_mode = MODE.movement;
        }
    }

    public void open_modal(MODAL modal)
    {
        if(current_mode == MODE.combat) { return; }

        current_modal = modal;
        current_mode = MODE.dialog;
        switch(modal)
        {
            case MODAL.battle:
                current_mode = MODE.combat;
                open_modal_battle();
                return;
            case MODAL.character:
                open_modal_character();
                return;
            case MODAL.equipment:
                open_modal_equipment();
                return;
            case MODAL.info:
                open_modal_info();
                return;
            case MODAL.pause:
                open_modal_pause();
                return;
            case MODAL.items:
                open_modal_items();
                return;
        }
    }

    public void open_modal(MODAL modal, string text)
    {
        open_modal(modal);
        set_info_dialog_text(text);
    }

    #region Battle Dialog Controls
    private void open_modal_battle()
    {
        battle_modal.Awake(); //Do any initialization necessary before loading
        //BattleMaster battle_master = battle_modal.gameObject.AddComponent<BattleMaster>();
        //battle_master.init(this, this, this, allies, enemies);
        //battle_master.startBattle();

        //battle_modal.set_target(enemy);

        //battle_modal.set_player_name_text(player.player_name);
        //battle_modal.update_player_health(player.HP, player.MAX_HP);

        //battle_modal.set_enemy_name_text(enemy.enemy_name);
        //battle_modal.update_enemy_health(enemy.HP, enemy.MAX_HP);

        //battle_modal.update_turn(turn);
        //battle_modal.set_battle_information("");

        //battle_modal.update_stats();

        //player_turn = true;
        battle_modal.open();
    }

    private void close_modal_battle()
    {
        //////////Destroy(battle_master);

        battle_modal.close();
    }
    #endregion

    #region Info Dialog Controls
    private void open_modal_info()
    {
        info_modal.Awake();

        info_modal.open();
    }

    private void open_modal_info(string info)
    {
        info_modal.Awake();

        info_modal.set_text(info);
        info_modal.open();
    }

    private void close_info_dialog()
    {
        info_modal.close();
    }

    private void set_info_dialog_text(string info)
    {
        info_modal.set_text(info);
    }
    #endregion

    #region Pause Dialog Controls
    private void open_modal_pause()
    {
        pause_modal.Awake();
        pause_modal.open();
    }

    private void close_pause_dialog()
    {
        pause_modal.close();
    }
    #endregion

    #region Character Dialog Controls
    private void open_modal_character()
    {
        character_modal.open();
    }

    private void close_character_dialog()
    {
        character_modal.close();
    }
    #endregion

    #region Equipment Dialog Controls
    private void open_modal_equipment()
    {
        equipment_modal.Awake();

        equipment_modal.load_armor_choices();
        equipment_modal.load_current_equipment();

        equipment_modal.open();
    }

    private void close_equipment_dialog()
    {
        equipment_modal.close();
    }
    #endregion

    #region Items Dialog Controls
    private void open_modal_items()
    {
        //Unneccessary because it's now called in the Awake(), which is 
        //automatically called every time the object is set ot active
        items_modal.open();
    }

    private void close_items_dialog()
    {
        items_modal.close();
    }
    #endregion
}
