using UnityEngine;
using UnityEngine.UI;

 public class HeartPulse : MonoBehaviour
{
    private float pulseSpeed = 0.2732f; // this is in seconds
    private float timer;
    private Image heart_img;
    private AudioSource audio_source;
    private AudioClip audio_clip;

    public void Awake()
    {
        heart_img = GetComponent<Image>();
        audio_source = GameObject.Find("Utility/HeartBeatAudioSource").GetComponent<AudioSource>();
        audio_clip = Resources.Load("beep") as AudioClip;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > pulseSpeed)
        {
            timer = 0;
            Color heart_color = heart_img.color;
            if (heart_color.a == 1)
            {
                heart_color.a = 0;
            }
            else
            {
                heart_color.a = 1;
                audio_source.PlayOneShot(audio_clip);
            }
            heart_img.color = heart_color; 
        }
    }
}