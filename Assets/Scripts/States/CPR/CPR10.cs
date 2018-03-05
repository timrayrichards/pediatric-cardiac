
public class CPR10 : CPR
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<SHR1>(); ;
        next_state = gameObject.GetComponent<SHR4>();

        base.Awake();
    }
}