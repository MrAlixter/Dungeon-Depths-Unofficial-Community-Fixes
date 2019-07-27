using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenuChoice : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public interface IHoverMenu
    {
        void OnChoicePointerEnter(GameObject choice);
        void OnChoicePointerExit(GameObject choice);
        void OnChoiceClick(Ability clicked_ability);
    }

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
    private bool hovered;

    // Start is called before the first frame update
    void Start()
    {
        hovered = false;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        hoverMenuCallback.OnChoiceClick(ability);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
        hoverMenuCallback.OnChoicePointerEnter(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
        hoverMenuCallback.OnChoicePointerExit(gameObject);
    }
}
