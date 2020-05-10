using System;

namespace Scripts
{
    [Serializable]
    public enum MODAL { none, battle, info, pause, character, equipment, items };

    [Serializable]
    public enum MODE { movement, dialog, combat };

    public interface IModalMaster
    {
        void end_battle();
        void switch_modal(MODAL modal);
        void switch_modal(MODAL modal, string message);
        MODAL current_modal { get; }
        MODE current_mode { get; }

        void update_battle_bars();

        bool is_in_combat { get; }
        bool is_in_dialog { get; }
        bool is_in_movement { get; }

        bool is_modal_none_open { get; }
        bool is_no_modal_open { get; }
        bool is_modal_battle_open { get; }
        bool is_modal_info_open { get; }
        bool is_modal_pause_open { get; }
        bool is_modal_character_open { get; }
        bool is_modal_equipment_open { get; }
        bool is_modal_items_open { get; }

        void end_combat_dialog(string message);

        //void open_modal_none();
        //void open_modal_battle();
        //void open_modal_info();
        //void open_modal_pause();
        //void open_modal_character();
        //void open_modal_equipment();
        //void open_modal_items();
    }
}
