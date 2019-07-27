using UnityEngine;

public class EquipmentChoice
{
    private GameObject gameObject;
    public UnityEngine.UI.Button button { get; set; }
    public UnityEngine.UI.Image image { get; set; }
    public UnityEngine.UI.Text name { get; set; }
    public UnityEngine.UI.Text description { get; set; }
    public UnityEngine.UI.Text stats { get; set; }
    public EquipmentChoiceInfo info { get; set; }
    public UIRectangle[] sizes { get; set; }

    public EquipmentChoice(GameObject rootGameObject)
    {
        gameObject = rootGameObject;
        button = gameObject.GetComponent<UnityEngine.UI.Button>();
        image = gameObject.transform.Find("Image").GetComponent<UnityEngine.UI.Image>();
        name = gameObject.transform.Find("Name Text").GetComponent<UnityEngine.UI.Text>();
        description = gameObject.transform.Find("Description Text").GetComponent<UnityEngine.UI.Text>();
        stats = gameObject.transform.Find("Stat Text").GetComponent<UnityEngine.UI.Text>();
        info = gameObject.transform.Find("Info").GetComponent<EquipmentChoiceInfo>();
        if (sizes == null)
        {
            sizes = new UIRectangle[9];
            GameObject s = gameObject.transform.Find("Sizes").gameObject;
            for(int i = -1; i <= 7; i++)
            {
                sizes[i+1] = s.transform.Find($"{i}").GetComponent<UIRectangle>();
            }
        }
    }
}