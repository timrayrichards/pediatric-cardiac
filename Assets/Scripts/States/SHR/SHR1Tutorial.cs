using UnityEngine;
using UnityEngine.UI;

public class SHR1Tutorial : SHR
{
    public override void Awake()
    {
        yes_state = gameObject.GetComponent<SHK3Tutorial>();
        no_state = null;
        base.Awake();
    }

    public void Start()
    {
        prev_btn.interactable = false; 
        no_btn.interactable = false; 
    }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        Speak("This stage asks you to determine whether the patients heart rate is shockable. Air tap the purple reference button for a reference on shockable heart rhythms. When you are ready, either air tap the yes button, or say yes.");
    }
}
