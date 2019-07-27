using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenu : MonoBehaviour, 
    HoverMenuChoice.IHoverMenu,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public Ability[] choices;
    private HoverMenuChoice[] choiceButtons;
    [SerializeField]
    private bool open;
    [SerializeField]
    private bool clicked;
    [SerializeField]
    private bool wasOpen;
    public GameObject childButtonPrefab;
    [SerializeField]
    private GameObject hoveredChild;
    private GameObject choicesContainer;

    // Start is called before the first frame update
    void Start()
    { 
        open = false;
        clicked = false;
        wasOpen = false;

        if(choices == null) { throw new System.Exception("No choices for " + name); }

        choicesContainer = transform.Find("ChoicesContainer").gameObject;
        for(int i = 0; i < choices.Length; i++)
        {
            GameObject button = Instantiate(childButtonPrefab, choicesContainer.transform);
            HoverMenuChoice hmc;
            button.AddComponent<HoverMenuChoice>();
            hmc = button.GetComponent<HoverMenuChoice>();
            hmc.setHoverMenuCallback(this);
            hmc.ability = choices[i];
            button.name = "ChoiceButton-"+choices[i];
        }
        CloseChildren();
    }

    // Update is called once per frame
    void Update()
    {
        //Already open, check for close
        if(wasOpen)
        {
            if(!open && !clicked && hoveredChild == null)
            {
                CloseChildren();
            }
        }
        //Already closed, check for open
        else
        {
            if(open || clicked || hoveredChild != null)
            {
                OpenChildren();
            }
        }
    }

    private void OpenChildren()
    {
        choicesContainer.SetActive(true);
        wasOpen = true;
    }

    private void CloseChildren()
    {
        open = false;
        choicesContainer.SetActive(false);
        hoveredChild = null;
        wasOpen = false;
    }

    public void OnChoiceClick(Ability clicked_ability)
    {
        //Debug.Log("Choice was clicked - " + clicked_ability.name);
        if(clicked_ability is Spell)
        {
            ((Spell)clicked_ability).cast();
        }
        else if(clicked_ability is Special)
        {
            ((Special)clicked_ability).perform();
        }
    }

    public void OnChoicePointerEnter(GameObject choice)
    {
        hoveredChild = choice;
    }

    public void OnChoicePointerExit(GameObject choice)
    {
        //If they already hovered over another one, don't disturb.
        //But if they aren't hovering over a new choice,
        //then we need to handle that.
        if(hoveredChild.Equals(choice)) { hoveredChild = null; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        open = true;
        clicked = !clicked;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        open = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        open = false;
    }
}
