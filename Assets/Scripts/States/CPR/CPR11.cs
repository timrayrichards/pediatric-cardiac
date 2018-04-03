
public class CPR11 : CPR
{
    public override void Awake()
    {
        next_state = gameObject.GetComponent<SHR5>();

        base.Awake();
    }
}