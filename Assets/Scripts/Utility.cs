using UnityEngine;

public class Utility : MonoBehaviour
{
    public enum TransitionType { Next, Previous, Yes, No }
    public bool Tutorial;

    public void Awake()
    {
        Tutorial = false; 
    }

    public string CalculateDosage(double dosage_per_kg, double weight)
    {
        return (dosage_per_kg * weight).ToString();
    }
}
