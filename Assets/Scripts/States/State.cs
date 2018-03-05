using UnityEngine;
using UnityEngine.UI;

public abstract class State : MonoBehaviour
{
    protected GameObject window;
    private AudioSource audio_source;
    private AudioClip audio_clip; 

    public virtual void Awake()
    {
        audio_source = GameObject.Find("Utility/AudioSource").GetComponent<AudioSource>();
        audio_clip = Resources.Load("click1") as AudioClip;
    }

    protected void Transition(State nextState)
    {
        PlaySound();
        window.SetActive(false);
        nextState.TransitionBegin();
        TransitionEnd();
        nextState.window.SetActive(true);
    }

    /* override in child for custom behavior 
     * called at the start and end of a transition */
    protected virtual void TransitionBegin() {}
    protected virtual void TransitionEnd() {}

    protected void AddTransitionBtnListener(Button btn, State state)
    {
        btn.onClick.AddListener(delegate { Transition(state); });
    }

    protected void SetupDetailListeners(Button btn, GameObject detail_window)
    {
        btn.onClick.AddListener(delegate { OpenSubWindow(detail_window); });
    }

    protected void OpenSubWindow(GameObject detail_window)
    {
        PlaySound();
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
        PlaySound();
        detail_window.SetActive(false);
        window.SetActive(true);
    }

    protected void InitWindow(string window_name)
    {
        window = Instantiate(Resources.Load(window_name) as GameObject, GameObject.Find("Views").transform);
    }

    private void PlaySound()
    {
        audio_source.PlayOneShot(audio_clip);
    }
}
