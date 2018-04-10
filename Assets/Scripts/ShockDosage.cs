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
    public string GetShockDosage(bool verbose)
    {
        string result = "";
    
        if (verbose)
        {
            result += "Shock with "; 
        }
        if (num_shocks == 0)
        {
            result = result + utility.CalculateDosage(2, weight);
        }
        else if (num_shocks == 1)
        {
            result = result + utility.CalculateDosage(4, weight);
        }
        else
        {
            if (verbose)
            {
                result = result + " between " + utility.CalculateDosage(4, weight) +
                " and " + utility.CalculateDosage(10, weight); 
            }
            else
            {
                result = result + " Between " + utility.CalculateDosage(4, weight) +
                " and " + utility.CalculateDosage(10, weight);
            }
        }
        if (verbose)
        {
            result += " Jewels"; // for speech to text pronounciation
        }
        else
        {
            result += " J";
        } 
        return result;
    }

    public void AdminShock()
    {
        ++num_shocks;
    }

    public void InitDosage()
    {
        num_shocks = 0; 
    }

}
