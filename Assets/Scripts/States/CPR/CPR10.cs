
public class CPR10 : CPR
{
    public override void Awake()
    {
        next_state = gameObject.GetComponent<SHR4>();

        base.Awake();
    }
}