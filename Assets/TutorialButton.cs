using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialButton : MonoBehaviour
{
    private int curr;
    public GameObject tutorialPanel;
    public Text titleText;
    public Button nextButton;
    public Button backButton;
    public Text buttonText;
    public Text mainText;
    public Sprite exitSprite;
    public AudioSource nextAudioSource;
    public AudioSource backAudioSource;
    public AudioClip buttonClip;

    private string[] titles = {
        "Overview",
        "Weight Input",
        "Navigation",
        "CPR",
        "SHR",
        "Shock",
        "Details",
        "End" };

    private string[] info = {
        "Pediatric Cardiac guides you through the American Heart " +
            "Assocation's pediatric cardiac arrest algorithm.",
        "Enter the patient's weight in kilograms using the numeric keypad. " +
            "This will be used to set dosages for drug therapy and shock energy.",
        "Press the 'Previous' or 'Next' buttons to navigate to different " +
            "steps.",
        "Perform CPR on the patient for two minutes and perform any " +
            "additional tasks given.",
        "Determine whether the patient's heart rhythm is shockable " +
            "— either pVT or VF.\nTap 'No' if the patient has stabilized.",
        "Defibrillate the patient according to the shock dosage given.\n" +
            "This dosage will increase with further shocks.",
        "At each step, you can also tap the green 'Detail' buttons for " +
            "more information on certain concepts.",
        "Once the patient has stabilized, you can return to the title " +
            "screen to begin again, or perform the 'Bloom' gesture to quit."
    };

    void SetText()
    {
        titleText.text = titles[curr];
        mainText.text = info[curr];
    }

    void Start()
    {
        curr = 0;
        SetText();
        SetButtons();
        Button btn1 = nextButton.GetComponent<Button>();
        Button btn2 = backButton.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnNext);
        btn2.onClick.AddListener(TaskOnBack);
    }

    void Reset()
    {
        curr = 0;
        SetText();
        SetButtons();
    }

    void TaskOnNext()
    {
        nextAudioSource.PlayOneShot(buttonClip, 2);
        curr++;
        if (curr == info.Length)
        {
            Reset();
            tutorialPanel.SetActive(false);
            return;
        }
        SetText();
        SetButtons();
    }

    void SetButtons()
    {
        if (curr == 0)
        {
            backButton.image.overrideSprite = exitSprite;
        }
        else
        {
            backButton.image.overrideSprite = null;
        }

        if (curr == info.Length - 1)
        {
            buttonText.text = "OK";
        }
        else
        {
            buttonText.text = "Next";
        }
    }

    void TaskOnBack()
    {
        backAudioSource.PlayOneShot(buttonClip, 2);
        if (curr == 0)
        {
            tutorialPanel.SetActive(false);
            return;
        }
        else
        {
            curr--;
            SetText();
            SetButtons();
        }
    }
}
