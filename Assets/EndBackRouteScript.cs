using UnityEngine;
using UnityEngine.UI;

public class EndBackRouteScript : MonoBehaviour {

    private Canvas canvas;
    private Button noButton;
    private Button endBackButton;
    
    void Start()
    {

        canvas = GetComponentInParent<Canvas>();

        noButton = GetComponent<Button>();
        noButton.onClick.AddListener(NoClicked);

        GameObject goButtons = noButton.transform.parent.gameObject.transform.parent.gameObject;
        GameObject goCards = goButtons.transform.parent.gameObject.transform.parent.gameObject;
        endBackButton = goCards.transform.Find("END/Buttons/Back").GetComponent<Button>();
    }

    void NoClicked()
    {
        endBackButton.onClick.RemoveAllListeners();
        endBackButton.onClick.AddListener(SetCanvas);
    }

    void SetCanvas()
    {
        canvas.enabled = true;
    }
}
