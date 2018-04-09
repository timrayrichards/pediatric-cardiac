
public class CPR4Tutorial : CPR
{
    int transition_count;

    public override void Awake()
    {
        next_state = gameObject.GetComponent<SHR2Tutorial>();
        transition_count = 0;
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        next_btn.interactable = false; 
    }

    protected override void PlayPrompt(Utility.TransitionType type) { }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        base.TransitionedTo(prev_state, type);
        if (transition_count % 2 == 0)
        {
            Speak("This stage is similar to the previous CPR stage, however, the tasks are different. If for whatever reason you wish to go back to a previous stage, use the previous button. Go ahead and do so now by either air tapping the previous button, or saying previous.");
            next_btn.interactable = false;
            prev_btn.interactable = true;
        }
        else
        {
            Speak("Continue by either air tapping the next button, or saying next.");
            next_btn.interactable = true;
            prev_btn.interactable = false;
        }
        ++transition_count;
    }
}