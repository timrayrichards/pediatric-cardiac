using UnityEngine;
using UnityEngine.UI;

public class CPRTimerScript : MonoBehaviour {
    
    public Text timerText;
    private float timer;
    private Canvas canvas;
    private bool wasEnabled;
    private Button nextButton;
  
    void Start() {
         
        timer = 120;
        canvas = GetComponentInParent<Canvas>();
        wasEnabled = false;
        timerText = GetComponent<Text>();

        GameObject card = timerText.transform.parent.gameObject.transform.parent.gameObject;
        nextButton = card.transform.Find("Buttons/Footer").GetComponent<Button>();
        nextButton.onClick.AddListener(NextClicked);
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
