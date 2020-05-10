using UnityEngine;
using UnityEngine.UI;

public class CharacterModal : Modal
{
    private static CharacterModal _instance;
    public static CharacterModal instance { get { if(_instance != null) { return _instance; } else { _instance = new CharacterModal(); return _instance; } } }

    private static GameObject equipmentButtonGO;
    private static GameObject itemsButtonGO;
    private static GameObject statsButtonGO;
    private static GameObject examineSelfButtonGO;

    private static Button equipmentButton;
    private static Button itemsButton;
    private static Button statsButton;
    private static Button examineSelfButton;

    public CharacterModal()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    public new void Awake()
    {
        base.Awake();

        Transform root = transform.Find("Panel");
        Transform buttonGroup = root.Find("Vertical Button Group");

        equipmentButtonGO = buttonGroup.Find("Equipment Button").gameObject;
        itemsButtonGO = buttonGroup.Find("Items Button").gameObject;
        statsButtonGO = buttonGroup.Find("Stats Button").gameObject;
        examineSelfButtonGO = buttonGroup.Find("Examine Self Button").gameObject;

        equipmentButton = equipmentButtonGO.GetComponent<Button>();
        itemsButton = itemsButtonGO.GetComponent<Button>();
        statsButton = statsButtonGO.GetComponent<Button>();
        examineSelfButton = examineSelfButtonGO.GetComponent<Button>();
    }

    protected override void SetDefault()
    {
        CustomEventSystem.instance.SetResetSelection(equipmentButton.GetComponent<Selectable>());
    }

    public override void open()
    {
        base.open();
        equipmentButton.Select();
    }
}
