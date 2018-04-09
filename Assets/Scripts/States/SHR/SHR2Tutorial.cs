using UnityEngine;
using UnityEngine.UI;

public class SHR2Tutorial : SHR
{
    public override void Awake()
    {
        yes_state = null;
        no_state = gameObject.GetComponent<End>();
        base.Awake();
    }

    public void Start()
    {
        prev_btn.interactable = false; 
        yes_btn.interactable = false;
    }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        Speak("This time indicate that the heart rate is not shockable by either air tapping the no button, or saying no.");
    }
}