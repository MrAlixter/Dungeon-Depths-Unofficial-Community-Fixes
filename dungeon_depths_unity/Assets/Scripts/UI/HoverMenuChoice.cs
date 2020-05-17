using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//I tried to genericize this but Unity doesn't support generic components (and thus MonoBehaviours)
public class HoverMenuChoice : MonoBehaviour,
    ISelectHandler,
    IDeselectHandler
{
    public interface IHoverMenu
    {
        void OnChoiceSelect(GameObject choice);
        void OnChoiceDeselect(GameObject choice);
        void OnChoiceClick(Ability clicked_ability);
    }

    public Button button { get { return GetComponent<Button>(); } }
    public Navigation navigation { get { return button.navigation; } set { button.navigation = value; } }
    public Selectable selectable { get { return GetComponent<Selectable>(); } }

    private Ability _choice_data;
    public Ability choice_data
    {
        get { return _choice_data; }
        set
        {
            _choice_data = value;
            set_text();
        }
    }
    public string text { get { return choice_data.ToString(); } }
    private IHoverMenu hoverMenuCallback;
    
    void Start()
    {
        button.onClick.AddListener(() => {
            button.Select();
            hoverMenuCallback.OnChoiceClick(choice_data);
        });
    }

    public void setHoverMenuCallback(IHoverMenu callback)
    {
        hoverMenuCallback = callback;
    }

    private void set_text()
    {
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = text;
    }

    public void OnSelect(BaseEventData eventData)
    {
        hoverMenuCallback.OnChoiceSelect(gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        hoverMenuCallback.OnChoiceDeselect(gameObject);
    }
}
