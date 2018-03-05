
public class CPR11 : CPR
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<SHR4>();
        next_state = gameObject.GetComponent<SHR5>();

        base.Awake();
    }
}