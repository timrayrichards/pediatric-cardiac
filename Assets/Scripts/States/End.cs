using UnityEngine;
using UnityEngine.UI;

public class End : State
{
    public GameObject end_window;
    private GameObject tutorial_text;
    private Button rosc_btn;

    public override void Awake()
    {
        base.Awake();
        
        InitWindow(end_window);

        State next_state = gameObject.GetComponent<CPR10>();
        AddTransition(next_state, Utility.TransitionType.Next);

        Button start_btn = window.transform.Find("Nav/StartScreen").GetComponent<Button>();
        start_btn.onClick.AddListener(StartScreenTransition);

        AddStaticDetailWindows();
 
        tutorial_text = GameObject.Find("ScreenOverlay/Tutorial");

        window.SetActive(false);  
    }

    private void StartScreenTransition()
    {
        Transition(gameObject.GetComponent<Title>(), Utility.TransitionType.Next);
    }

    private void AddStaticDetailWindows()
    {
        rosc_btn = window.transform.Find("DetailButtons/Rosc").GetComponent<Button>();
        GameObject Rosc_window = GameObject.Find("Views/Details/Rosc");
        SetupDetailListeners(rosc_btn, Rosc_window);
    }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        if (tutorial_text.activeSelf)
        {
            prev_btn.interactable = false;
            rosc_btn.interactable = false;
            next_btn.interactable = false;
            Speak("This is the conclusion of the tutorial. Either air tap the start screen button.");
        }
        else
        {
            prev_btn.interactable = true;
            rosc_btn.interactable = true;
            next_btn.interactable = true;
            Speak("Check pulse. If pulse present administer post-cardiac care. If asystole either air tap the asystole button, or say next.");
        }
    }
}