using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationModal : Modal, CustomToggle.IToggleHandler
{
    private static MainModal main_modal;
    private static DungeonGeneratorSettingsModal dungeon_generator_settings_modal;

    public static void init(MainModal main_modal, DungeonGeneratorSettingsModal dungeon_generator_settings_modal)
    {
        CharacterCreationModal.main_modal = main_modal;
        CharacterCreationModal.dungeon_generator_settings_modal = dungeon_generator_settings_modal;
    }
    
    private static GameObject back_go;
    private static GameObject finalize_go;
    private static GameObject sex_go;

    private static Button back_button;
    private static Button finalize_button;
    private static SlideSwitch sex_button;

    protected override void SetDefault()
    {
        //Called automatically from menu.open()
        Player.event_system.SetSelectedGameObject(finalize_go);
    }

    protected override void ModalStart()
    {
        back_go = panel.Find("Back Button").gameObject;
        finalize_go = panel.Find("Finalize Button").gameObject;
        sex_go = panel.Find("Sex Slide").gameObject;

        back_button = back_go.GetComponent<Button>();
        finalize_button = finalize_go.GetComponent<Button>();
        sex_button = sex_go.GetComponent<SlideSwitch>();


        sex_button.set_toggle_handler(this);
    }

    public void back()
    {
        modal_master.try_switch_modal(MODAL.MAIN);
    }

    public void finalize()
    {
        modal_master.try_switch_modal(MODAL.DUNGEON_GENERATOR_SETTINGS);
    }

    public void toggled()
    {
        //May need to be changed if anything other than sex is handled by a toggler
        //TODO 
    }
}
