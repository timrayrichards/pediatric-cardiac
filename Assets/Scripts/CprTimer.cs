using UnityEngine;
using UnityEngine.UI;

public class CprTimer : MonoBehaviour
{    
    private AudioSource audio_source;
    private AudioClip audio_clip;
    private Text timer_text;
    private bool sound_played;
    private float time;
    public bool play_sound; // set by others

    public void Awake()
    {
        timer_text = null;
        play_sound = false;
        sound_played = false;

        audio_source = GameObject.Find("Utility/TimeUpAudioSource").GetComponent<AudioSource>();
        audio_clip = Resources.Load("timer_up") as AudioClip; 
    }

    public void SetText(Text text)
    {
        timer_text = text;
    }

    void Update ()
    {
        if (time > 0)
        {
            timer_text.text = "Seconds remaining: " + GetSecondsRemaining();
            time -= Time.deltaTime;
        }
        else
        {
            time = 0; 
            timer_text.text = "CPR step complete";
            if (!sound_played && play_sound)
            {
                audio_source.PlayOneShot(audio_clip); 
            }
            sound_played = true;
        }
    }

    public string GetSecondsRemaining()
    {
        return time.ToString("F0");
    }

    public void SetTime(float time)
    {
        this.time = time;
        sound_played = false;
    }
}
