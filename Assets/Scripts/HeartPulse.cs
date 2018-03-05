using UnityEngine;
using UnityEngine.UI;

 public class HeartPulse : MonoBehaviour
{
    private float pulseSpeed = 0.2732f; // this is in seconds
    private float timer;
    private Image heart_img;

    public void Awake()
    {
        heart_img = GetComponent<Image>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > pulseSpeed)
        {
            timer = 0;
            Color heart_color = heart_img.color;
            heart_color.a = (heart_color.a == 1 ? 0 : 1);
            heart_img.color = heart_color; 
        }
    }
}