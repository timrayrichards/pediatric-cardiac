using UnityEngine;
using UnityEngine.UI;

public class SetDetailDosages : MonoBehaviour
{
    private Text epinephrine_txt;
    private Text amiodarone_txt;
    private Text lidocaine_txt;
    private Utility utility;

    public void Awake()
    {
        utility = GameObject.Find("Utility").GetComponent<Utility>();

        epinephrine_txt = GameObject.Find("Views/Details/Epinephrine/Text/Bullets").GetComponent<Text>();
        amiodarone_txt = GameObject.Find("Views/Details/Amiodarone/Text/Bullets").GetComponent<Text>();
        lidocaine_txt = GameObject.Find("Views/Details/Lidocaine/Text/Bullets").GetComponent<Text>();
    }

    public void SetDosages(double weight)
    {
        epinephrine_txt.text = "• " + utility.CalculateDosage(0.01, weight) + " mg. Repeat\n  every 3-5min\n\n" +
            "• If no IO / IV access, may\n  give endotracheal dose:\n  " + utility.CalculateDosage(0.1, weight) + " mg";

        amiodarone_txt.text = "• " + utility.CalculateDosage(5, weight) + " mg bolus\n  during cardiac arrest\n\n" +
            "• May repeat up to 2 times\n  for refractory VF/ pulseless VT";

        lidocaine_txt.text = "• Initial: " + utility.CalculateDosage(1, weight) + " mg\n  loading dose\n\n" +
            "• Maintainence: [" + utility.CalculateDosage(20, weight) + ", " + utility.CalculateDosage(50, weight) + "]\n  mcg per minute infusion\n  " +
            "(repeat bolus dose if infusion\n  initiated > 15min after initial\n  bolus therapy)";
    }
}