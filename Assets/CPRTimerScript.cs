using UnityEngine;
using UnityEngine.UI;

public class CPRTimerScript : MonoBehaviour {
    
    public Text timerText;
    private Canvas canvas;
    private Button nextButton;
    private Button backButton;
    private bool wasEnabled;
    private float timer;

    void Start() {
         
        timer = 120;
        canvas = GetComponentInParent<Canvas>();
        wasEnabled = false;
        timerText = GetComponent<Text>();

        GameObject card = timerText.transform.parent.gameObject.transform.parent.gameObject;
        nextButton = card.transform.Find("Buttons/Footer").GetComponent<Button>();
        nextButton.onClick.AddListener(NextClicked);

        backButton = card.transform.Find("Buttons/Back").GetComponent<Button>();
        backButton.onClick.AddListener(NextClicked);
    }

    void Update () {

        if (canvas.isActiveAndEnabled) wasEnabled = true;
        if (!wasEnabled) return;

        if (timer > 0)
        {
            timerText.text = "Time remaining: " + timer.ToString("F0");
            timer -= Time.deltaTime;
        }
    }

    void NextClicked()
    {
        timer = 120;
        wasEnabled = false;
    }
}
