using HoloToolkit.UI.Keyboard;
using HoloToolkit.Unity;
using UnityEngine;
using UnityEngine.UI;


public class Title : State
{
    public Keyboard keyboard;
    public GameObject title_window;

    private SimpleTagalong tag_along_script;
    private Billboard billboard_script;
    private SetDetailDosages set_detail_dosages;
    private ShockDosage shock_dosage;

    private Text input_txt, feedback_txt;
    private State next_state;
    private GameObject tutorial_text;
    private Button tutorial_btn; 

    private double weight;

    bool played_prompt;

    private string prompt;
    private string prompt1 = "Enter patient weight and press go.";
    
    public override void Awake()
    {
        base.Awake();

        InitWindow(title_window);
        AddNavButtonListeners();

        tag_along_script = title_window.transform.parent.GetComponent<SimpleTagalong>();
        billboard_script = title_window.transform.parent.GetComponent<Billboard>(); 

        input_txt = window.transform.Find("InputField/UserInput").GetComponent<Text>();
        feedback_txt = window.transform.Find("Feedback").GetComponent<Text>();

        set_detail_dosages = GameObject.Find("Model").GetComponent<SetDetailDosages>();
        shock_dosage = GameObject.Find("Model").GetComponent<ShockDosage>();

        next_state = gameObject.GetComponent<CPR1>();
        tutorial_text = GameObject.Find("ScreenOverlay/Tutorial");

        played_prompt = false; 
        prompt = prompt1;
        weight = 0;

        window.SetActive(true);
        model.SetCurrentState(this);
    }

    public void Start()
    {
        tutorial_text.SetActive(false);
    }

    private void AddNavButtonListeners()
    {
        Button submit_btn = window.transform.Find("Submit").GetComponent<Button>();
        tutorial_btn = window.transform.Find("Tutorial").GetComponent<Button>();
        submit_btn.onClick.AddListener(Submit);
        tutorial_btn.onClick.AddListener(InitTutorial);
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
        if (!played_prompt)
        {
            Speak(prompt);
            played_prompt = true; 
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

    private void InitStandard()
    { 
        tutorial_btn.interactable = true; 
        next_state = gameObject.GetComponent<CPR1>();
        prompt = prompt1;
        played_prompt = false; 
    }

    private void InitTutorial()
    {
        keyboard.Enter();
        EnableScreenFollow();
        tutorial_text.SetActive(true);
        tutorial_btn.interactable = false; 
        next_state = gameObject.GetComponent<CPR1Tutorial>();
        prompt = "This is the start window. Move your head around and you'll see that the window follows your gaze. Move your head until the window is in an ideal spot, and then air tap the white input field to open the keyboard. Use the keyboard to enter a patient weight value and then air tap the go button.";
        played_prompt = false;
    }

    private void Submit()
    {
        if (!ParseInput()) return;
        shock_dosage.SetWeight(weight);
        set_detail_dosages.SetDosages(weight);
        feedback_txt.text = "Patient weight (kg)";
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
        tutorial_text.SetActive(false);
    }

    protected override void TransitionedFrom()
    {
        InitStandard();
        DisableScreenFollow();
    }
}

