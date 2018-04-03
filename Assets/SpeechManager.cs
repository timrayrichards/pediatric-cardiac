using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

public class SpeechManager : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer = null;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    private Model model;

    public void Awake()
    {
        model = GameObject.Find("Model").GetComponent<Model>();
        keywords.Add("Previous", () =>
        {
            State current_state = model.GetCurrentState();
            if (current_state != null)
            {
                current_state.InvokeTransition(Utility.TransitionType.Previous);
            }
        });
        keywords.Add("Next", () =>
        {
            State current_state = model.GetCurrentState();
            if (current_state != null)
            {
                current_state.InvokeTransition(Utility.TransitionType.Next);
            }
        });
        keywords.Add("Yes", () =>
        {
            State current_state = model.GetCurrentState();
            if (current_state != null)
            {
                current_state.InvokeTransition(Utility.TransitionType.Yes);
            }
        });
        keywords.Add("No", () =>
        {
            State current_state = model.GetCurrentState();
            if (current_state != null)
            {
                current_state.InvokeTransition(Utility.TransitionType.No);
            }
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();

    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
