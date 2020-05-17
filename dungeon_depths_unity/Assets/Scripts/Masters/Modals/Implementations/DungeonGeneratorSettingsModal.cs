using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DungeonGeneratorSettingsModal : Modal//, CustomToggle.IToggleHandler
{
    private static IGameMaster game_master;
    
    private static GameObject back_go;
    private static GameObject finalize_go;
    //private static GameObject sex_go;

    private static Button back_button;
    private static Button finalize_button;
    //private static SlideSwitch sex_button;

    protected override void SetDefault()
    {
        //Called automatically from menu.open()
        Player.event_system.SetSelectedGameObject(finalize_go);
    }

    protected override void ModalStart()
    {
        game_master = Master.get_master<IGameMaster>();

        back_go = panel.Find("Back Button").gameObject;
        finalize_go = panel.Find("Finalize Button").gameObject;
        //sex_go = panel.Find("Sex Slide").gameObject;

        back_button = back_go.GetComponent<Button>();
        finalize_button = finalize_go.GetComponent<Button>();
        //sex_button = sex_go.GetComponent<SlideSwitch>();


        //sex_button.set_toggle_handler(this);
    }
    
    public void back()
    {
        modal_master.try_switch_modal(MODAL.CHARACTER_CREATION);
    }

    public void finalize()
    {
        modal_master.force_switch_modal(MODAL.NONE);
        game_master.new_game();
    }

    public void toggled()
    {
        //May need to be changed if anything other than sex is handled by a toggler
        //TODO 
    }
}
