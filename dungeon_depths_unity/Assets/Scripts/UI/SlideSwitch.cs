using UnityEngine;
using UnityEngine.EventSystems;

public class SlideSwitch : CustomToggle
{
    private float SWITCH_TIME = 0.1f;

    private IToggleHandler toggleHandler;
    private UIRectangle background;
    private UIRectangle slideBackground;
    private Transform slide;

    private bool can_toggle;
    private bool at_left;
    
    private new void Awake()
    {
        Transform backing = transform.Find("Backing");
        background = backing.Find("Background").GetComponent<UIRectangle>();
        slide = transform.Find("Slide");
        slideBackground = slide.Find("Slide Background").GetComponent<UIRectangle>();

        can_toggle = true;
        at_left = true;

        slideBackground.color = Color.gray;
    }

    public override void OnSelect(BaseEventData eventData)
    {
        slideBackground.color = Master.highlightColor;
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        slideBackground.color = Color.gray;
    }

    public void set_toggle_handler(IToggleHandler th) { toggleHandler = th; }

    public override void OnSubmit(BaseEventData eventData)
    {
        if(can_toggle)
        {
            can_toggle = false;
            float start_x = slide.localPosition.x;
            float target_x = start_x * -1;
            Tweener.TweenInTime(slide.transform, "localPosition.x", target_x, SWITCH_TIME, callback: done_tweening);
            toggleHandler.toggled();
        }
    }

    private void done_tweening()
    {
        can_toggle = true;
        at_left = !at_left;
    }
}
