
public class CPR1 : CPR
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<Title>();
        next_state = gameObject.GetComponent<SHR1>();

        base.Awake();
    }
}