
public class CPR4 : CPR
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<SHK3>(); ;
        next_state = gameObject.GetComponent<SHR2>();

        base.Awake();
    }
}