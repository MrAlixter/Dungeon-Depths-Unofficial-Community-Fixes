using System;

namespace Scripts
{
    [Serializable]
    public enum MODAL { NONE, COMBAT, INFO, PAUSE, CHARACTER, EQUIPMENT, ITEMS, MAIN, STATS, CHARACTER_CREATION, DUNGEON_GENERATOR_SETTINGS };

    [Serializable]
    public enum MODE { MOVEMENT, DIALOG, COMBAT };

    public interface IModalMaster
    {
        Modal get_instance(MODAL modal);
        T get_interfaced_modal<T>();

        //void end_battle();
        //void switch_modal(MODAL modal);
        //void switch_modal(MODAL modal, string message);
        //MODAL current_modal { get; }
        //MODE current_mode { get; }
        void try_switch_modal(MODAL modal);
        void force_switch_modal(MODAL modal);
        void try_open_modal(MODAL modal);
        void force_open_modal(MODAL modal);

        //void update_battle_bars();

        bool is_in_combat { get; }
        bool is_in_dialog { get; }
        bool is_in_movement { get; }

        //bool is_modal_none_open { get; }
        //bool is_no_modal_open { get; }
        //bool is_modal_battle_open { get; }
        //bool is_modal_info_open { get; }
        //bool is_modal_pause_open { get; }
        //bool is_modal_character_open { get; }
        //bool is_modal_equipment_open { get; }
        //bool is_modal_items_open { get; }
        //bool is_modal_main_open { get; }

        //void end_combat_dialog(string message);

        //void leave_main_menu();

        //void open_modal_none();
        //void open_modal_battle();
        //void open_modal_info();
        //void open_modal_pause();
        //void open_modal_character();
        //void open_modal_equipment();
        //void open_modal_items();

        bool is_modal_open(MODAL modal);
        bool is_modal_allowed_to_open_over(MODAL modal);
        bool is_modal_allowed_to_switch(MODAL modal);

        void try_open_message_modal(string message, bool overwrite);
        void try_switch_message_modal(string message, bool overwrite);
    }
}
