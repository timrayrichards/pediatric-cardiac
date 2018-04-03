using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {

	private State current_state = null;
    
    public void SetCurrentState(State state)
    {
        current_state = state; 
    }

    public State GetCurrentState()
    {
        return current_state; 
    }
}
