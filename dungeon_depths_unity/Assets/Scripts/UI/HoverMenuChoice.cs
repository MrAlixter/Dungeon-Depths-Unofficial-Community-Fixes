using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    private Ability _ability;
    public Ability ability
    {
        get { return _ability; }
        set
        {
            _ability = value;
            set_text();
        }
    }
    public string text { get { return ability.name; } }
    private IHoverMenu hoverMenuCallback;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => {
            button.Select();
            hoverMenuCallback.OnChoiceClick(ability);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHoverMenuCallback(IHoverMenu callback)
    {
        hoverMenuCallback = callback;
    }

    private void set_text()
    {
        transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = text;
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
