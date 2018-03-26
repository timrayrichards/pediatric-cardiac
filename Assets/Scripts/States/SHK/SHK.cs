using UnityEngine;
using UnityEngine.UI;

public class SHK : State
{
    private Text shock_dosage_txt;
    private ShockDosage shock_dosage;
    private bool shocked = false; 

    /* assign in child */
    protected State prev_state, next_state; 

    /* child must call this after it sets above states */
    public override void Awake()
    {
        InitWindow("SHK");
        AddNavButtonListeners();
        shock_dosage_txt = window.transform.Find("ShockDosage").GetComponent<Text>();
        shock_dosage = GameObject.Find("Model").GetComponent<ShockDosage>(); 
        window.SetActive(false);

        base.Awake();
    }

    private void AddNavButtonListeners()
    {
        Button prev_btn = window.transform.Find("Nav/Previous").GetComponent<Button>();
        Button next_btn = window.transform.Find("Nav/Next").GetComponent<Button>();
        AddTransitionBtnListener(prev_btn, prev_state);
        AddTransitionBtnListener(next_btn, next_state);
    }

    protected override void TransitionedTo()
    {
        if (!shocked)
        {
            shock_dosage_txt.text = shock_dosage.GetShockDosage();
            shocked = true; 
        }
    }
}
