using UnityEngine;
using UnityEngine.UI;

public class SHR : State
{
    /* assign in child */
    protected State yes_state, no_state;

    /* child must call this after it sets above states */ 
    public override void Awake()
    {
        base.Awake();

        InitWindow("SHR");
        AddTransition(yes_state, Utility.TransitionType.Yes);
        AddTransition(no_state, Utility.TransitionType.No);
        AddStaticDetailWindows(); 

        window.SetActive(false);
    }

    private void AddStaticDetailWindows()
    {
        Button rhythms_btn = window.transform.Find("DetailButtons/Rhythms").GetComponent<Button>();
        GameObject rhythms_window = GameObject.Find("Views/Details/Shockable_rhythms");
        SetupDetailListeners(rhythms_btn, rhythms_window);
    }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        Speak("Is patient heartrate shockable?");
    }
}

