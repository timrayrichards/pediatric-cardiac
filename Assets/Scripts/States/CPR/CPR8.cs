
public class CPR8 : CPR
{
    public override void Awake()
    { 
        next_state = gameObject.GetComponent<SHR2>();

        base.Awake();
    }
}