using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverMenu : MonoBehaviour, 
    HoverMenuChoice.IHoverMenu,
    //IPointerClickHandler,
    //IPointerEnterHandler,
    //IPointerExitHandler,
    //ISelectHandler,
    IDeselectHandler
{
    public Ability[] choices;
    private List<HoverMenuChoice> choiceButtons;
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

    private Button button { get { return GetComponent<Button>(); } }
    private Navigation navigation { get { return button.navigation; } set { button.navigation = value; } }
    private Selectable selectable { get { return GetComponent<Selectable>(); } }

    private Selectable normalDown;

    // Start is called before the first frame update
    void Start()
    { 
        open = false;
        clicked = false;
        wasOpen = false;

        if(choices == null) { throw new System.Exception("No choices for " + name); }

        choiceButtons = new List<HoverMenuChoice>();

        Navigation nav;
        HoverMenuChoice previous = null;
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

            if(previous != null)
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
        nav = choiceButtons[0].navigation;
        nav.selectOnUp = selectable;
        choiceButtons[0].navigation = nav;

        CloseChildren();
        
        button.onClick.AddListener(() => {
            clicked = !clicked;
        });

        normalDown = navigation.selectOnDown;
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

        Navigation nav = navigation;
        nav.selectOnDown = choiceButtons[0].selectable;
        navigation = nav;

        CustomEventSystem.getEventSystem().SetSelectedGameObject(choiceButtons[0].gameObject);
    }

    private void CloseChildren()
    {
        open = false;
        choicesContainer.SetActive(false);
        hoveredChild = null;
        wasOpen = false;

        Navigation nav = navigation;
        nav.selectOnDown = normalDown;
        navigation = nav;

        CustomEventSystem.getEventSystem().SetSelectedGameObject(gameObject);
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
        CloseChildren();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        open = false;
        hoveredChild = null;
        clicked = false;
    }

    public void OnChoiceSelect(GameObject choice)
    {
        hoveredChild = choice;
    }

    public void OnChoiceDeselect(GameObject choice)
    {
        //If they already hovered over another one, don't disturb.
        //But if they aren't hovering over a new choice,
        //then we need to handle that.
        if (hoveredChild == null) { return; }
        if (hoveredChild.Equals(choice)) { hoveredChild = null; }
    }
}
