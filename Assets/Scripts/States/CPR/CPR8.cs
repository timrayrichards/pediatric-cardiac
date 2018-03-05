
public class CPR8 : CPR
{
    public override void Awake()
    { 
        prev_state = gameObject.GetComponent<SHK7>(); ;
        next_state = gameObject.GetComponent<SHR2>();

        base.Awake();
    }
}