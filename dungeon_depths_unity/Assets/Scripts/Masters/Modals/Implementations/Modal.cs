using Scripts;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public abstract class Modal : MonoBehaviour
{
    protected static IModalMaster _modal_master;
    protected static IModalMaster modal_master { get { if(_modal_master == null) { _modal_master = Master.get_master<IModalMaster>(); } return _modal_master; } }
    
    protected static char SEP = Path.DirectorySeparatorChar;
    protected static GameObject ui_event_system;
    protected static EventSystem event_system;
    protected static InputSystemUIInputModule ui_input_module;

    protected RectTransform panel;

    private void Awake()
    {
        if(!ui_event_system) { ui_event_system = Resources.Load<GameObject>("Prefabs"+SEP+"UI"+SEP+"UIEventSystem"); }
    }
    
    protected abstract void ModalStart();
    public virtual void init()
    {
        //Instantiate(ui_event_system, transform);
        //event_system = ui_event_system.GetComponent<EventSystem>();
        //ui_input_module = ui_event_system.GetComponent<InputSystemUIInputModule>();
        //Player.input.uiInputModule = ui_input_module;
        //ui_input_module = gameObject.AddComponent<InputSystemUIInputModule>();
        //ui_input_module.actionsAsset = Player.ui_input.actionsAsset;
        //ui_input_module.leftClick = Player.ui_input.leftClick;
        //Player.input.uiInputModule = ui_input_module;
        //PlayerInput pi = gameObject.AddComponent<PlayerInput>();
        //pi.actions

        Transform p = transform.Find("Panel");
        if(p != null) //If it's child is where the panel is...
        {
            panel = p.GetComponent<RectTransform>();
        }
        else //Otherwise, it is the panel
        {
            panel = GetComponent<RectTransform>();
        }

        Transform backgroundFade;
        if(panel.parent != null)
        {
            if(panel.parent.name.Contains("Battle Menu"))
            {
                //Skip adding the function for the Battle Menu
                return;
            }
            backgroundFade = panel.parent.Find("Background Fade");
        }
        else
        {
            backgroundFade = panel.Find("Background Fade");
        }

        if(backgroundFade != null)
        {
            OverridableButton b = backgroundFade.GetComponent<OverridableButton>();
            b.customOnClick = ask_to_close;
        }
        ModalStart(); //Implemented by the children who use it to set their own variable setting (mostly "panel.Find()")
        SetDefault();
    }

    public virtual void open()
    {
        active = true;
        init();
        //CustomEventSystem.instance.SelectDefault();
    }

    public virtual void close()
    {
        //Previously selected buttons will stay selected and refuse to be unselected 
        //via any means besides selecting it and then something else. However, 
        //there's no way to see if a button/toggle is selected unless it is the 
        //event system's currently selected game object, which it almost certainly
        //won't be when the menu is reopened. 
        //To fix this, I have to unselect it before the object goes inactive
        EventSystem.current.SetSelectedGameObject(null);
        active = false;
        //Master.instance.switch_dialog(MENU.none); //Causes stack overflow
    }

    public bool active
    {
        get { return gameObject.activeInHierarchy; }
        protected set { gameObject.SetActive(value); }
    }

    //Abstract to force children to override it so that it can be called in init()
    //This way I have to make a concious decision to not make a default button 
    //for when it's not needed (info menu and health bar).
    protected abstract void SetDefault();

    private void ask_to_close()
    {
        modal_master.try_switch_modal(Scripts.MODAL.NONE);
    }
}
