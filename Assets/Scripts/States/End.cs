using UnityEngine;

public class End : State
{
    public GameObject end_window;
    private GameObject tutorial_text;

    public override void Awake()
    {
        base.Awake();
        
        InitWindow(end_window);

        State next_state = gameObject.GetComponent<Title>();
        AddTransition(next_state, Utility.TransitionType.Next);

        tutorial_text = GameObject.Find("ScreenOverlay/Tutorial");

        window.SetActive(false);  
    }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        if (tutorial_text.activeSelf)
        {
            prev_btn.interactable = false;
            Speak("Helpful message. Air tap title button to go back to the main menu.");
        }
        else
        {
            prev_btn.interactable = true;
            Speak("Helpful message.");
        }
    }
}