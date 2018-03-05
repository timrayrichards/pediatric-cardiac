using UnityEngine;
using UnityEngine.UI;

public class SHR : State
{
    /* assign in child */
    protected State prev_state, yes_state, no_state;

    /* child must call this after it sets above states */ 
    public override void Awake()
    {
        InitWindow("SHR");
        AddNavButtonListeners();
        AddStaticDetailWindows(); 
        window.SetActive(false);

        base.Awake();
    }

    private void AddNavButtonListeners()
    {
        Button prev_btn = window.transform.Find("Nav/Previous").GetComponent<Button>();
        Button yes_btn = window.transform.Find("Nav/Yes").GetComponent<Button>();
        Button no_btn = window.transform.Find("Nav/No").GetComponent<Button>();
        AddTransitionBtnListener(prev_btn, prev_state);
        AddTransitionBtnListener(yes_btn, yes_state);
        AddTransitionBtnListener(no_btn, no_state);
    }

    private void AddStaticDetailWindows()
    {
        Button rhythms_btn = window.transform.Find("DetailButtons/Rhythms").GetComponent<Button>();
        GameObject rhythms_window = GameObject.Find("Views/Details/Shockable_rhythms");
        SetupDetailListeners(rhythms_btn, rhythms_window);
    }
}

