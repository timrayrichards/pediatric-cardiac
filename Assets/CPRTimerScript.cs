using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPRTimerScript : MonoBehaviour {

    public Text timerText;
    private float timer;
    private bool wasEnabled;
    private bool endReached;
    private int delay;

    void Start() {
         
        timerText = GetComponent<Text>();
        timer = 120;
        wasEnabled = false;
        endReached = false;
    }
    
    void Update () {
      
        if (endReached && delay > 0)
        {
            --delay;
            return;
        }

        endReached = false;
        delay = 200;

        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas.isActiveAndEnabled) wasEnabled = true;
        if (!wasEnabled) return;

        if (timer > 0)
        {
            timerText.text = "Time remaining: " + timer.ToString("F0");
            timer -= Time.deltaTime;
        }
        else
        {
            
            wasEnabled = false;
            timerText.text = "CPR step complete\n Proceed to next step";
            timer = 120;
            endReached = true;
        }
    }
}
