using UnityEngine;

public class ShockDosage : MonoBehaviour
{
    private double weight;
    private int num_shocks;
    private Utility utility; 

    public void Awake ()
    {
        weight = 0;
        num_shocks = 0;
        utility = GameObject.Find("Utility").GetComponent<Utility>(); 
	}

    public void SetWeight(double weight)
    {
        this.weight = weight;
    }

    /* first SetWeight */
    public string GetShockDosage()
    {
        string result = "";
        if (num_shocks == 0)
        {
            result += utility.CalculateDosage(2, weight) + " J";
        }
        else if (num_shocks == 1)
        {
            result += utility.CalculateDosage(4, weight) + " J";
        }
        else
        {
            result += "[" + utility.CalculateDosage(4, weight) + ", " + utility.CalculateDosage(10, weight) + "] J";
        }
        ++num_shocks; 
        return result;
    }
}
