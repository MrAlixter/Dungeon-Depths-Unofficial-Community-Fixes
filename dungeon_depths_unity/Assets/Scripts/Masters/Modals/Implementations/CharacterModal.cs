using UnityEngine;
using UnityEngine.UI;

public class CharacterModal : Modal
{
    private static GameObject equipment_button_go;
    private static GameObject items_button_go;
    private static GameObject stats_button_go;
    private static GameObject examine_self_button_go;

    private static Button equipment_button;
    private static Button items_button;
    private static Button stats_button;
    private static Button examine_self_button;

    protected override void ModalStart()
    {
        Transform root = transform.Find("Panel");
        Transform buttonGroup = root.Find("Vertical Button Group");

        equipment_button_go = buttonGroup.Find("Equipment Button").gameObject;
        items_button_go = buttonGroup.Find("Items Button").gameObject;
        stats_button_go = buttonGroup.Find("Stats Button").gameObject;
        examine_self_button_go = buttonGroup.Find("Examine Self Button").gameObject;

        equipment_button = equipment_button_go.GetComponent<Button>();
        items_button = items_button_go.GetComponent<Button>();
        stats_button = stats_button_go.GetComponent<Button>();
        examine_self_button = examine_self_button_go.GetComponent<Button>();
    }

    protected override void SetDefault()
    {
        Player.event_system.SetSelectedGameObject(equipment_button_go);
    }
}
