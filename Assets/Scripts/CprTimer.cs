using UnityEngine;
using UnityEngine.UI;

public class CprTimer : MonoBehaviour
{    
    private AudioSource audio_source;
    private AudioClip audio_clip;
    private Text timer_text;
    private bool sound_played;
    private float timer;

    public void Awake()
    {
        timer = 120;
        sound_played = false;
        timer_text = GetComponent<Text>();

        audio_source = GameObject.Find("Utility/TimeUpAudioSource").GetComponent<AudioSource>();
        audio_clip = Resources.Load("beep") as AudioClip; 

        AddNavButtonListeners();
    }

    private void AddNavButtonListeners()
    {
        Button prev_btn = gameObject.transform.parent.Find("Nav/Previous").GetComponent<Button>();
        Button next_btn = gameObject.transform.parent.Find("Nav/Next").GetComponent<Button>();
        prev_btn.onClick.AddListener(ResetTimer);
        next_btn.onClick.AddListener(ResetTimer);
    }

    void Update ()
    { 
        if (timer > 0)
        {
            timer_text.text = "Seconds remaining: " + timer.ToString("F0");
            timer -= Time.deltaTime;
        }
        else
        {
            timer_text.text = "CPR step complete";
            if (!sound_played)
            {
                audio_source.PlayOneShot(audio_clip);
                sound_played = true;
            }
        }
    }

    void ResetTimer()
    {
        timer = 120;
    }
}
