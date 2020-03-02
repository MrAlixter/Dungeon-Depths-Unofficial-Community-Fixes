using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentChoice : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Button button { get; set; }
    public UIRectangle background { get; set; }
    public Image image { get; set; }
    public Text nameText { get; set; }
    public Text description { get; set; }
    public Text stats { get; set; }
    public int id { get { return info.id; } set { info.id = value; } }
    private EquipmentChoiceInfo info { get; set; }
    public UIRectangle[] sizes { get; set; }

    public static IEnsureVisible<EquipmentChoice> ensureVisibleMaster;

    public void Awake()
    {
        button = gameObject.GetComponent<Button>();
        background = gameObject.GetComponent<UIRectangle>();
        image = gameObject.transform.Find("Image").GetComponent<Image>();
        nameText = gameObject.transform.Find("Name Text").GetComponent<Text>();
        description = gameObject.transform.Find("Description Text").GetComponent<Text>();
        stats = gameObject.transform.Find("Stat Text").GetComponent<Text>();
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

    public void OnSelect(BaseEventData eventData)
    {
        background.color = Master.highlightColor;
        ensureVisibleMaster.ensure_visible(this);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        background.color = Color.black;
    }
}