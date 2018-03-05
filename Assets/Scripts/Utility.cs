using UnityEngine;

public class Utility : MonoBehaviour
{
    public string CalculateDosage(double dosage_per_kg, double weight)
    {
        return (dosage_per_kg * weight).ToString();
    }
}
