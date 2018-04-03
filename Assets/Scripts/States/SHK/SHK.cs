using UnityEngine;
using UnityEngine.UI;

public class SHK : State
{
    private Text shock_dosage_txt;
    private ShockDosage shock_dosage;
    private bool shocked = false; 

    /* assign in child */
    protected State next_state; 

    /* child must call this after it sets above states */
    public override void Awake()
    {
        base.Awake();

        InitWindow("SHK");
        AddTransition(next_state, Utility.TransitionType.Next);
        
        shock_dosage_txt = window.transform.Find("ShockDosage").GetComponent<Text>();
        shock_dosage = GameObject.Find("Model").GetComponent<ShockDosage>(); 

        window.SetActive(false);
    }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        if (!shocked && type != Utility.TransitionType.Previous)
        {
            shock_dosage_txt.text = shock_dosage.GetShockDosage(false);
            Speak(shock_dosage.GetShockDosage(true));
            shock_dosage.AdminShock();
            shocked = true; 
        }
    }

    protected override void TransitionedFrom()
    {
        shocked = false; 
    }
}
