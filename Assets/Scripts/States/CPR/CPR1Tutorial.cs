using UnityEngine;
using UnityEngine.UI;

public class CPR1Tutorial : CPR
{
    public override void Awake()
    {
        next_state = gameObject.GetComponent<SHR1Tutorial>();
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        prev_btn.interactable = false;
    }

    protected override void PlayPrompt(Utility.TransitionType type)
    {
        Speak("This is a CPR stage, which prompts you to administer CPR for two minutes. If at anytime you would like to move the window, simply air tap the window once, then move your head, and tap the window once more to place it. The purple button is a reference button. Air tap this button and a new window detailing proper CPR methods will appear. To close this window air tap the close button, or focus your gaze on the close button and say select. Once back to the CPR window advance by either air tapping the next button or simply saying next.");
    }
}