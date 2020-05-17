using UnityEngine;
using UnityEngine.UI;
using Scripts;

public class PauseModal : Modal
{
    private GameObject saveButtonGO;
    private GameObject loadButtonGO;
    private GameObject optionsButtonGO;
    private GameObject quitButtonGO;

    private Button saveButton;
    private Button loadButton;
    private Button optionsButton;
    private Button quitButton;

    private static IGameMaster game_master;

    protected override void ModalStart()
    {
        game_master = Master.get_master<IGameMaster>();

        Transform root = transform.Find("Panel");
        Transform buttonGroup = root.Find("Vertical Button Group");

        saveButtonGO = buttonGroup.Find("Save Button").gameObject;
        loadButtonGO = buttonGroup.Find("Load Button").gameObject;
        optionsButtonGO = buttonGroup.Find("Options Button").gameObject;
        quitButtonGO = buttonGroup.Find("Quit Button").gameObject;

        saveButton = saveButtonGO.GetComponent<Button>();
        loadButton = loadButtonGO.GetComponent<Button>();
        optionsButton = optionsButtonGO.GetComponent<Button>();
        quitButton = quitButtonGO.GetComponent<Button>();
    }

    protected override void SetDefault()
    {
        Player.event_system.SetSelectedGameObject(saveButtonGO);
    }

    public override void open()
    {
        base.open();
        saveButton.Select();
    }

    public void save()
    {
        game_master.save_game(1);
    }

    public void load()
    {
        modal_master.try_switch_modal(MODAL.NONE);
        game_master.load_game(1);
    }
}