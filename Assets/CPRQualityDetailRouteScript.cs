using UnityEngine;
using UnityEngine.UI;

public class CPRQualityDetailRouteScript : MonoBehaviour
{
    private Canvas origin;
    private Button detailButton;
    private Button detailCloseButton;

    void Start()
    {
        origin = GetComponentInParent<Canvas>();

        detailButton = GetComponent<Button>();
        detailButton.onClick.AddListener(DetailClicked);

        GameObject goButtons = detailButton.transform.parent.gameObject;
        GameObject goCards = goButtons.transform.parent.gameObject.transform.parent.gameObject;
        detailCloseButton = goCards.transform.Find("CPR-QUALITY-DETAIL/Buttons/Footer").GetComponent<Button>();
    }

    void DetailClicked()
    {
        detailCloseButton.onClick.RemoveAllListeners();
        detailCloseButton.onClick.AddListener(SetCanvas);
    }

    void SetCanvas()
    {
        origin.enabled = true;
    }
}
