using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public abstract class State : MonoBehaviour
{
    protected GameObject window;
    protected Model model;
    private AudioSource audio_source;
    private AudioClip audio_clip;
    private TextToSpeech text_to_speech;
    private Button prev_btn;
    private Button next_btn;
    private Button yes_btn;
    private Button no_btn; 
    private bool sub_window_open;

    public virtual void Awake()
    {
        // find/load private references
        model = GameObject.Find("Model").GetComponent<Model>();
        audio_source = GameObject.Find("Utility/NavAudioSource").GetComponent<AudioSource>();
        text_to_speech = GameObject.Find("TextToSpeech").GetComponent<TextToSpeech>();
        audio_clip = Resources.Load("beep") as AudioClip;

        sub_window_open = false; 
    }

    protected void InitWindow(string window_name)
    {
        GameObject window = Instantiate(Resources.Load(window_name) as GameObject, GameObject.Find("Views").transform);
        InitWindow(window);
    }

    protected void InitWindow(GameObject window)
    {
        this.window = window;
        Transform prev = window.transform.Find("Nav/Previous");
        Transform next = window.transform.Find("Nav/Next");
        Transform yes = window.transform.Find("Nav/Yes");
        Transform no = window.transform.Find("Nav/No");
        this.prev_btn = prev ? prev.GetComponent<Button>() : null;
        this.next_btn = next ? next.GetComponent<Button>() : null;
        this.yes_btn = yes ? yes.GetComponent<Button>() : null;
        this.no_btn = no ? no.GetComponent<Button>() : null;
    }

    protected void Transition(State nextState, Utility.TransitionType type)
    {
        text_to_speech.StopSpeaking();
        PlayTransitionSound();
        window.SetActive(false);
        // update their previous state btn
        if (type != Utility.TransitionType.Previous && nextState.prev_btn)
        {
            nextState.AddTransition(this, Utility.TransitionType.Previous);
        }
        TransitionedFrom();
        nextState.TransitionedTo(this, type);
        model.SetCurrentState(nextState);
        nextState.window.SetActive(true);
    }

    protected void Speak(string words)
    {
        text_to_speech.StartSpeaking(words);
    }

    /* override in child for custom behavior 
     * called at the start and end of a transition */
    protected virtual void TransitionedTo(State prev_state, Utility.TransitionType type) {}
    protected virtual void TransitionedFrom() {}

    protected void AddTransition(State state, Utility.TransitionType type)
    {
        Button btn = null;
        switch (type)
        {
            case Utility.TransitionType.Previous:
                btn = prev_btn;
                break;
            case Utility.TransitionType.Next:
                btn = next_btn;
                break;
            case Utility.TransitionType.No:
                btn = no_btn;
                break;
            case Utility.TransitionType.Yes:
                btn = yes_btn; 
                break;
        }
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate { Transition(state, type); });
    }

    public void InvokeTransition(Utility.TransitionType type)
    {
        switch (type)
        {
            case Utility.TransitionType.Previous:
                InvokeTransitionBtn(prev_btn);
                break;
            case Utility.TransitionType.Next:
                InvokeTransitionBtn(next_btn);
                break;
            case Utility.TransitionType.No:
                InvokeTransitionBtn(no_btn);
                break;
            case Utility.TransitionType.Yes:
                InvokeTransitionBtn(yes_btn);
                break;
        }
    }

    public void InvokeTransitionBtn(Button btn)
    {
        if (!btn || sub_window_open)
        {
            // TODO: invalid transition
        }
        else
        {
            btn.onClick.Invoke();
        }
    }

    protected void SetupDetailListeners(Button btn, GameObject detail_window)
    {
        btn.onClick.AddListener(delegate { OpenSubWindow(detail_window); });
    }

    protected void OpenSubWindow(GameObject detail_window)
    {
        PlayTransitionSound();
        sub_window_open = true; 
        AddDetailCloseBtnListener(detail_window);
        window.SetActive(false);
        detail_window.SetActive(true);
    }

    protected void AddDetailCloseBtnListener(GameObject detail_window)
    {
        Button close_btn = detail_window.transform.Find("Close").GetComponent<Button>();
        close_btn.onClick.RemoveAllListeners();
        close_btn.onClick.AddListener(delegate { CloseSubWindow(detail_window); });
    }

    protected void CloseSubWindow(GameObject detail_window)
    {
        PlayTransitionSound();
        sub_window_open = false;
        detail_window.SetActive(false);
        window.SetActive(true);
    }

    private void PlayTransitionSound()
    {
        audio_source.PlayOneShot(audio_clip);
    }
}
