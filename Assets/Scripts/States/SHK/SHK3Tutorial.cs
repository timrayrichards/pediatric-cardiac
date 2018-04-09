using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHK3Tutorial : SHK
{
    int transition_count; 

    public override void Awake()
    {
        next_state = gameObject.GetComponent<CPR4Tutorial>();
        transition_count = 0;
        base.Awake();
    }

    public void Start()
    {
        prev_btn.interactable = false;
    }

    protected override void PlayPrompt()
    {
        if (transition_count % 2 == 0)
        {
            Speak("This is the shock stage. It provides you with the recommended shock voltage, which depends on the weight of the patient and number of shocks received thus far. When ready, either air tap the next button, or say next.");
        }
        else
        {
            Speak("Continue by either air tapping the next button, or saying next.");
        }
        ++transition_count; 
    }
}
