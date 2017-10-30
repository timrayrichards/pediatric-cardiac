using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightDosageScript : MonoBehaviour {

    private Canvas title;
    private Canvas cpr_start;
    private Text inputLabel;
    
    private Button startButton;
    private GameObject goWeightInput;
    private double weight;

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
        inputLabel = goWeightInput.transform.Find("Label").GetComponent<Text>();
        GameObject goCards = goWeightInput.transform.parent.gameObject.transform.parent.gameObject;

        title = goCards.transform.Find("TITLE").GetComponent<Canvas>();
        cpr_start = goCards.transform.Find("CPR-1").GetComponent<Canvas>();       
 
        // grab all dosage text objects
        shock_3 = goCards.transform.Find("SHK-3/Text/Subheader").GetComponent<Text>();
        shock_5 = goCards.transform.Find("SHK-5/Text/Subheader").GetComponent<Text>();
        shock_5_2 = goCards.transform.Find("SHK-5-2/Text/Subheader").GetComponent<Text>();
        shock_7 = goCards.transform.Find("SHK-7/Text/Subheader").GetComponent<Text>();

        epinephrine = goCards.transform.Find("EPINEPHRINE-DETAIL/Text/Subheader").GetComponent<Text>();
        amiodarone = goCards.transform.Find("AMIODARONE-DETAIL/Text/Subheader").GetComponent<Text>();
        lidocaine = goCards.transform.Find("LIDOCAINE-DETAIL/Text/Subheader").GetComponent<Text>();
    }

    void setDosages()
    {
        weight = int.Parse(goWeightInput.transform.Find("InputField/Text").GetComponent<Text>().text);
        if (weight < 0)
        {
            inputLabel.text = "Please enter a non-negative patient weight in kg";
            return;
        }

        //Set Shock dosages
        shock_3.text = "• " + calculateDosage(2) + " J";
        shock_5.text = "• " + calculateDosage(4) + " J";
        
        string intervalDosage = "• [" + calculateDosage(4) + ", " + calculateDosage(10) + "] J";
        shock_5_2.text = intervalDosage;
        shock_7.text = intervalDosage;

        //Set medicine dosages
        epinephrine.text = "• " + calculateDosage(0.01) + " mg. Repeat every 3-5min\n• If no IO / IV access, may give endotracheal dose: " + calculateDosage(0.1) + " mg";
        amiodarone.text = "• " + calculateDosage(5) + " mg bolus during cardiac arrest\n• May repeat up to 2 times for refractory VF/ pulseless VT";
        lidocaine.text = "• Initial: " + calculateDosage(1) + " mg loading dose\n• Maintainence: [" + calculateDosage(20) + ", " + calculateDosage(50) + "] mcg per minute infusion\n(repeat bolus dose if infusion initiated > 15min after initial bolus therapy)";

        title.enabled = false;
        cpr_start.enabled = true;
    }

    private string calculateDosage(double dosagePerKG)
    {
        return (dosagePerKG * weight).ToString();
    }
}
