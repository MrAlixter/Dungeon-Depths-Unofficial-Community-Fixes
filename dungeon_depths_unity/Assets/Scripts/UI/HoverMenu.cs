using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//I tried to genericize this but Unity doesn't support generic components (and thus MonoBehaviours)
public class HoverMenu : MonoBehaviour,
    HoverMenuChoice.IHoverMenu,
    //IPointerClickHandler,
    //IPointerEnterHandler,
    //IPointerExitHandler,
    //ISelectHandler,
    IDeselectHandler
{
    public interface HoverMenuChoiceHandler
    {
        void onHoverMenuChoiceClicked(Ability choice);
    }

    private HoverMenuChoiceHandler hoverMenuChoiceCallback;

    private Ability[] choices;
    private List<HoverMenuChoice> choiceButtons;
    [SerializeField]
    private bool can_open;
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

    public Button button { get { return GetComponent<Button>(); } }
    public Navigation navigation { get { return button.navigation; } set { button.navigation = value; } }
    public Selectable selectable { get { return GetComponent<Selectable>(); } }

    private Selectable normalDown;

    public void init(HoverMenuChoiceHandler hmch, GameObject childButtonPrefab, Ability[] abilities, bool can_open)
    {
        hoverMenuChoiceCallback = hmch;
        this.childButtonPrefab = childButtonPrefab;

        this.choices = abilities;

        this.can_open = can_open;
        open = false;
        clicked = false;
        wasOpen = false;

        if (choices == null) { throw new System.Exception("No choices for " + name); }

        if (choiceButtons != null) { choiceButtons.ForEach(cb => Destroy(cb.gameObject)); }
        choiceButtons = new List<HoverMenuChoice>();


        normalDown = navigation.selectOnDown;

        Navigation nav;
        HoverMenuChoice previous = null;
        choicesContainer = transform.Find("ChoicesContainer").gameObject;
        for (int i = 0; i < choices.Length; i++)
        {
            GameObject button = Instantiate(childButtonPrefab, choicesContainer.transform);
            HoverMenuChoice hmc;
            button.AddComponent<HoverMenuChoice>();
            hmc = button.GetComponent<HoverMenuChoice>();
            hmc.setHoverMenuCallback(this);
            hmc.choice_data = choices[i];
            button.name = "ChoiceButton-" + choices[i];

            if (previous != null)
            {
                nav = hmc.navigation;
                nav.selectOnUp = previous.selectable;
                nav.selectOnLeft = navigation.selectOnLeft;
                nav.selectOnRight = navigation.selectOnRight;
                hmc.navigation = nav;

                nav = previous.navigation;
                nav.selectOnDown = hmc.selectable;
                nav.selectOnLeft = navigation.selectOnLeft;
                nav.selectOnRight = navigation.selectOnRight;
                previous.navigation = nav;
            }

            choiceButtons.Add(hmc);
            previous = hmc;
        }

        if (choiceButtons.Count > 0)
        {
            nav = choiceButtons[0].navigation;
            nav.selectOnUp = selectable;
            choiceButtons[0].navigation = nav;
        }

        button.onClick.RemoveAllListeners(); //Prevent multiple listeners (there's no way to get attached listeners) 
        button.onClick.AddListener(() => {
            clicked = !clicked;
        });

        //Don't reselect, since this is the start and I don't want to override any
        //other selection that was initialized earlier
        CloseChildren(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!can_open) { return; }
        //Already open, check for close
        if (wasOpen)
        {
            if (!open && !clicked && hoveredChild == null)
            {
                CloseChildren();
            }
        }
        //Already closed, check for open
        else
        {
            if (open || clicked || hoveredChild != null)
            {
                OpenChildren();
            }
        }
    }

    private void OpenChildren()
    {
        if (!can_open) { return; }
        if (choiceButtons.Count < 1) { return; }
        choicesContainer.SetActive(true);
        wasOpen = true;

        Navigation nav = navigation;
        nav.selectOnDown = choiceButtons[0].selectable;
        navigation = nav;

        choiceButtons[0].button.Select();
    }

    private void CloseChildren(bool reselect = false)
    {
        if (!can_open) { return; }
        open = false;
        choicesContainer.SetActive(false);
        hoveredChild = null;
        wasOpen = false;

        Navigation nav = navigation;
        nav.selectOnDown = normalDown;
        navigation = nav;
        
        if(reselect) { button.Select(); }
    }

    public void OnChoiceClick(Ability clicked_data)
    {
        if (!can_open) { return; }
        //Debug.Log("Choice was clicked - " + clicked_ability.name);
        //if (clicked_ability is Spell)
        //{
        //    ((Spell)clicked_ability).cast();
        //}
        //else if(clicked_ability is Special)
        //{
        //    ((Special)clicked_ability).perform();
        //}
        
        CloseChildren();
        button.Select(); //Must go before the onHoverMenuChoiceClicked() to enable redirection

        hoverMenuChoiceCallback.onHoverMenuChoiceClicked(clicked_data);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (!can_open) { return; }
        open = false;
        hoveredChild = null;
        clicked = false;
    }

    public void OnChoiceSelect(GameObject choice)
    {
        if (!can_open) { return; }
        hoveredChild = choice;
    }

    public void OnChoiceDeselect(GameObject choice)
    {
        if (!can_open) { return; }
        //If they already hovered over another one, don't disturb.
        //But if they aren't hovering over a new choice,
        //then we need to handle that.
        if (hoveredChild == null) { return; }
        if (hoveredChild.Equals(choice)) { hoveredChild = null; }
    }

    public void set_can_open(bool can_open) {
        this.can_open = can_open;
        if(!can_open) { CloseChildren(false); }
    }
}
