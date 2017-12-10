using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightDosageScript : MonoBehaviour {

    private Button startButton;
    private GameObject goWeightInput;
    private double weight;

    // Objects for rerouting on bad inputs
    private Canvas title;
    private Canvas cpr_1;
    private Text prompt;

    // Dosage objects
    private Text shock_3;
    private Text shock_5;
    private Text shock_5_2;
    private Text shock_7;

    private Text epinephrine;
    private Text amiodarone;
    private Text lidocaine;

    // Use this for initialization
    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(setDosages);

        goWeightInput = startButton.transform.parent.gameObject;
        GameObject goCards = goWeightInput.transform.parent.gameObject.transform.parent.gameObject;

        // prompt on invalid inputs
        title = GetComponentInParent<Canvas>();
        cpr_1 = goCards.transform.Find("CPR-1").GetComponent<Canvas>();
        prompt = goCards.transform.Find("TITLE/Text/InvalidInputPrompt").GetComponent<Text>(); 

        shock_3 = goCards.transform.Find("SHK-3/Text/Subheader").GetComponent<Text>();
        shock_5 = goCards.transform.Find("SHK-5/Text/Subheader").GetComponent<Text>();
        shock_5_2 = goCards.transform.Find("SHK-5-2/Text/Subheader").GetComponent<Text>();
        shock_7 = goCards.transform.Find("SHK-7/Text/Subheader").GetComponent<Text>();

        epinephrine = goCards.transform.Find("EPINEPHRINE-DETAIL/Text/Bullets").GetComponent<Text>();
        amiodarone = goCards.transform.Find("AMIODARONE-DETAIL/Text/Bullets").GetComponent<Text>();
        lidocaine = goCards.transform.Find("LIDOCAINE-DETAIL/Text/Bullets").GetComponent<Text>();
    }

    void setDosages()
    {
        string weightInputText = goWeightInput
                 .transform.Find("InputField/Text")
                 .GetComponent<Text>().text;
        if (weightInputText == "" 
            || weightInputText == "-" 
            || weightInputText == "."
            || weightInputText == "-.")
        {
            title.enabled = true;
            cpr_1.enabled = false;
            prompt.text = "Please enter a valid positive weight";
            return;
        }

        weight = double.Parse(weightInputText);
        if (weight <= 0)
        {
            title.enabled = true;
            cpr_1.enabled = false;
            prompt.text = "Please enter a valid positive weight";
            return;
        }

        //Set Shock dosages
        shock_3.text = "• " + calculateDosage(2) + " J";
        shock_5.text = "• " + calculateDosage(4) + " J";
        
        string intervalDosage = "• [" + calculateDosage(4) + ", " + calculateDosage(10) + "] J";
        shock_5_2.text = intervalDosage;
        shock_7.text = intervalDosage;

        //Set medicine dosages
        epinephrine.text = "• " + calculateDosage(0.01) + " mg. Repeat\n  every 3-5min\n\n• If no IO / IV access, may\n  give endotracheal dose:\n  " + calculateDosage(0.1) + " mg";
        amiodarone.text = "• " + calculateDosage(5) + " mg bolus\n  during cardiac arrest\n\n• May repeat up to 2 times\n  for refractory VF/ pulseless VT";
        lidocaine.text = "• Initial: " + calculateDosage(1) + " mg\n  loading dose\n\n• Maintainence: [" + calculateDosage(20) + ", " + calculateDosage(50) + "]\n  mcg per minute infusion\n  (repeat bolus dose if infusion\n  initiated > 15min after initial\n  bolus therapy)";
        prompt.text = "";
    }

    string calculateDosage(double dosagePerKG)
    {
        return (dosagePerKG * weight).ToString();
    }
}
