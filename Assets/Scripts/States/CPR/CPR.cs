using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPR : State
{
    /* assign in child */
    protected State prev_state, next_state;

    /* assign in inspector */
    public List<GameObject> tasks = new List<GameObject>();
    public List<GameObject> details;

    /* child must call this after it sets above variables */
    public override void Awake()
    {
        InitWindow("CPR");
        AddNavButtonListeners();
        AddStaticDetailWindows();
        AddDynamicDetailWindows();
        AddTasks();
        window.SetActive(false);

        base.Awake();
    }

    private void AddNavButtonListeners()
    {
        Button prev_btn = window.transform.Find("Nav/Previous").GetComponent<Button>();
        Button next_btn = window.transform.Find("Nav/Next").GetComponent<Button>();
        AddTransitionBtnListener(next_btn, next_state);
        AddTransitionBtnListener(prev_btn, prev_state);
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
}