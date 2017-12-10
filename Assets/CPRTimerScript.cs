using UnityEngine;
using UnityEngine.UI;

public class CPRTimerScript : MonoBehaviour
{    
    public Text timerText;
    public AudioSource timerEndSound;
    public AudioClip click1;
    private Canvas canvas;
    private Button nextButton;
    private Button backButton;
    private bool wasEnabled;
    private bool soundPlayed;
    private float timer;

    void Start()
    {
         
        timer = 120;
        soundPlayed = false;
        canvas = GetComponentInParent<Canvas>();
        wasEnabled = false;
        timerText = GetComponent<Text>();

        GameObject card = timerText.transform.parent.gameObject.transform.parent.gameObject;
        nextButton = card.transform.Find("Buttons/Next").GetComponent<Button>();
        nextButton.onClick.AddListener(NextClicked);

        backButton = card.transform.Find("Buttons/Previous").GetComponent<Button>();
        backButton.onClick.AddListener(NextClicked);
    }

    void Update ()
    {

        if (canvas.isActiveAndEnabled) wasEnabled = true;
        if (!wasEnabled) return;

        if (timer > 0)
        {
            timerText.text = "Time remaining: " + timer.ToString("F0");
            timer -= Time.deltaTime;
        } else
        {
            timerText.text = "CPR step complete";

            if (!soundPlayed)
            {
                timerEndSound.PlayOneShot(click1);
                soundPlayed = true;
            }
        }
    }

    void NextClicked()
    {
        timer = 120;
        wasEnabled = false;
    }
}
