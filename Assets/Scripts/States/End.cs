using UnityEngine;

public class End : State
{
    public GameObject end_window;

    public override void Awake()
    {
        base.Awake();
        
        InitWindow(end_window);
        State next_state = gameObject.GetComponent<Title>();
        AddTransition(next_state, Utility.TransitionType.Next);

        window.SetActive(false);  
    }
}