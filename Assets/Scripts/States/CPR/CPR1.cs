
public class CPR1 : CPR
{
    public override void Awake()
    {
        next_state = gameObject.GetComponent<SHR1>();
        base.Awake();
    }
}