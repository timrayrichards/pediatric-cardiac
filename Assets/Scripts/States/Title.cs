using HoloToolkit.UI.Keyboard;
using HoloToolkit.Unity;
using UnityEngine;
using UnityEngine.UI;


public class Title : State
{
    public Keyboard keyboard;
    public GameObject rhythm_indicator;
    public GameObject title_window;
    private SimpleTagalong tag_along_script;
    private Billboard billboard_script;
    private Text input_txt, feedback_txt;
    private State next_state;
    private SetDetailDosages set_detail_dosages;
    private ShockDosage shock_dosage;
    private double weight;
    private bool played_voice_prompt = false;
    
    public override void Awake()
    {
        base.Awake();

        InitWindow(title_window);
        AddNavButtonListeners();

        // find/load private references
        tag_along_script = title_window.transform.parent.GetComponent<SimpleTagalong>();
        billboard_script = title_window.transform.parent.GetComponent<Billboard>(); 
        input_txt = window.transform.Find("InputField/UserInput").GetComponent<Text>();
        feedback_txt = window.transform.Find("Feedback").GetComponent<Text>();
        set_detail_dosages = GameObject.Find("Model").GetComponent<SetDetailDosages>();
        shock_dosage = GameObject.Find("Model").GetComponent<ShockDosage>();
        next_state = gameObject.GetComponent<CPR1>();

        weight = 0;
        rhythm_indicator.SetActive(false);
        window.SetActive(true);
        model.SetCurrentState(this);
    }

    private void AddNavButtonListeners()
    {
        Button submit_btn = window.transform.Find("Submit").GetComponent<Button>();
        submit_btn.onClick.AddListener(Submit);
    }

    public void Update()
    {
        if (!window.activeSelf)
        {
            return;
        }
        if (keyboard.isActiveAndEnabled)
        {
            DisableScreenFollow();
        }
        else
        {
            EnableScreenFollow();
        }
        if (!played_voice_prompt)
        {
            Speak("Please enter patient weight, and press go.");
            played_voice_prompt = true; 
        }
    }

    private void EnableScreenFollow()
    {
        tag_along_script.enabled = true;
        billboard_script.enabled = true; 
    }

    private void DisableScreenFollow()
    {
        tag_along_script.enabled = false;
        billboard_script.enabled = false;
    }

    private void Submit()
    {
        if (!ParseInput()) return;
        shock_dosage.SetWeight(weight);
        set_detail_dosages.SetDosages(weight);
        feedback_txt.text = "";
        Transition(next_state, Utility.TransitionType.Next);
        keyboard.Enter();
    }

    private bool ParseInput()
    {
        if (input_txt.text == "." || input_txt.text == "" || input_txt.text[0] == '0')
        {
            feedback_txt.text = "Please enter a valid positive weight";
            return false; 
        }
        weight = double.Parse(input_txt.text);
        return true; 
    }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        shock_dosage.InitDosage();
        rhythm_indicator.SetActive(false);
        played_voice_prompt = false;
    }

    protected override void TransitionedFrom()
    {
        DisableScreenFollow();
        rhythm_indicator.SetActive(true);
    }
}

