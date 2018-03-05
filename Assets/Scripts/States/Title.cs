using HoloToolkit.UI.Keyboard;
using UnityEngine;
using UnityEngine.UI;

public class Title : State
{
    public Keyboard keyboard;
    private Text input_txt, feedback_txt;
    private State next_state;
    private SetDetailDosages set_detail_dosages;
    private ShockDosage shock_dosage;
    private double weight;

    public override void Awake()
    {
        InitWindow("Title");
        AddNavButtonListeners();
        input_txt = window.transform.Find("InputField/UserInput").GetComponent<Text>();
        feedback_txt = window.transform.Find("Feedback").GetComponent<Text>();
        next_state = gameObject.GetComponent<CPR1>();
        set_detail_dosages = GameObject.Find("Model").GetComponent<SetDetailDosages>();
        shock_dosage = GameObject.Find("Model").GetComponent<ShockDosage>(); 
        weight = 0;
        window.SetActive(true);

        base.Awake();
    }

    private void AddNavButtonListeners()
    {
        Button submit_btn = window.transform.Find("Submit").GetComponent<Button>();
        submit_btn.onClick.AddListener(Submit);
    }

    private void Submit()
    {
        if (!ParseInput()) return;
        shock_dosage.SetWeight(weight);
        set_detail_dosages.SetDosages(weight);
        feedback_txt.text = "";
        Transition(next_state);
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
}

