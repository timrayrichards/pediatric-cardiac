using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPR : State
{
    /* assign in child */
    protected State next_state;

    /* assign in inspector */
    public List<GameObject> tasks = new List<GameObject>();
    public List<GameObject> details;

    private GameObject rhythm_indicator;
    private CprTimer timer;
    private Text timer_text; 

    /* child must call this after it sets above variables */
    public override void Awake()
    {
        base.Awake();

        InitWindow("CPR");
        AddTransition(next_state, Utility.TransitionType.Next);

        AddStaticDetailWindows();
        AddDynamicDetailWindows();
        AddTasks();

        rhythm_indicator = GameObject.Find("RhythmIndicator");

        timer = Instantiate(Resources.Load("Timer") as GameObject,
            GameObject.Find("Model/Timers").transform).GetComponent<CprTimer>();
        timer_text = window.transform.Find("TimerText").GetComponent<Text>();
        timer.SetText(timer_text);
        
        window.SetActive(false);
    }

    public void Start()
    {
        rhythm_indicator.SetActive(false);
    }

    private void AddStaticDetailWindows()
    {
        Button Cpr_qual_btn = window.transform.Find("DetailButtons/Cpr_quality").GetComponent<Button>();
        GameObject Cpr_qual_window = GameObject.Find("Views/Details/Cpr_quality");
        SetupDetailListeners(Cpr_qual_btn, Cpr_qual_window);
    }
       
    private void AddDynamicDetailWindows()
    {
        Button btn_template = (Resources.Load("Cpr_ref_btn") as GameObject).GetComponent<Button>();
        Transform parent = window.transform.Find("DetailButtons").gameObject.transform;

        foreach (GameObject detail in details)
        {
            Button btn = Instantiate(btn_template, parent).GetComponent<Button>();

            string btn_title = detail.transform.Find("ButtonTitle").GetComponent<Text>().text;
            btn.transform.Find("Text").GetComponent<Text>().text = btn_title;

            SetupDetailListeners(btn, detail);
        }
    }

    private void AddTasks()
    {
        Transform parent = window.transform.Find("Tasks/Grid").gameObject.transform;
        foreach (GameObject task in tasks)
        {
            Instantiate(task, parent);
        }
    }

    protected override void TransitionedTo(State prev_state, Utility.TransitionType type)
    {
        rhythm_indicator.SetActive(true);
        timer.play_sound = true;  

        if (type == Utility.TransitionType.Previous)
        {
            Speak(timer.GetSecondsRemaining() + " seconds remaining.");
        }
        else {
            timer.SetTime(120);
            Speak("Administer CPR for two minutes.");
        }
    }

    protected override void TransitionedFrom()
    {
        rhythm_indicator.SetActive(false);
        timer.play_sound = false; 
    }
}