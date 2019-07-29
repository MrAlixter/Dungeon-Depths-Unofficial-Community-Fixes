using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Menu
{
    private static PauseMenu _instance;
    public static PauseMenu instance { get { return _instance != null ? _instance : new PauseMenu(); } }

    private static GameObject saveButtonGO;
    private static GameObject loadButtonGO;
    private static GameObject optionsButtonGO;
    private static GameObject quitButtonGO;

    private static Button saveButton;
    private static Button loadButton;
    private static Button optionsButton;
    private static Button quitButton;

    public PauseMenu()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    public new void Awake()
    {
        base.Awake();

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

    public override void open()
    {
        base.open();
        saveButton.Select();
    }
}