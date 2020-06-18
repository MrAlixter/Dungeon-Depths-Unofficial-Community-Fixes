using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MainModal : Modal
{
    private static IGameMaster game_master;

    private static Selectable last_resort_default;

    private static GameObject start_game_go;
    private static GameObject load_game_go;
    private static GameObject controls_go;
    private static GameObject settings_go;
    private static GameObject about_go;

    private static Button start_game_button;
    private static Button load_game_button;
    private static Button controls_button;
    private static Button settings_button;
    private static Button about_button;

    protected override void SetDefault()
    {
        //Called automatically from menu.open()
        Player.event_system.SetSelectedGameObject(start_game_go);
    }

    protected override void ModalStart()
    {
        game_master = Master.get_master<IGameMaster>();

        start_game_go = panel.Find("Start New Game Button").gameObject;
        load_game_go = panel.Find("Load Game Button").gameObject;
        controls_go = panel.Find("Controls Button").gameObject;
        settings_go = panel.Find("Settings Button").gameObject;
        about_go = panel.Find("About Button").gameObject;

        start_game_button = start_game_go.GetComponent<Button>();
        load_game_button = load_game_go.GetComponent<Button>();
        controls_button = controls_go.GetComponent<Button>();
        settings_button = settings_go.GetComponent<Button>();
        about_button = about_go.GetComponent<Button>();
    }

    public void new_game()
    {
        modal_master.try_switch_modal(MODAL.CHARACTER_CREATION);
    }

    public void load()
    {
        modal_master.force_switch_modal(MODAL.NONE);
        game_master.load_game(1);
    }
}
