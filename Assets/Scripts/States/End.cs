using UnityEngine.UI;

public class End : State
{
    public override void Awake()
    {
        InitWindow("End");
        AddNavButtonListeners();
        window.SetActive(false);

        base.Awake();
    }

    private void AddNavButtonListeners()
    {
        Button next_btn = window.transform.Find("Buttons/Next").GetComponent<Button>();
        State next_state = gameObject.GetComponent<Title>();
        AddTransitionBtnListener(next_btn, next_state);
    }
}