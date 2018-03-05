
public class CPR6 : CPR
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<SHR2>();
        next_state = gameObject.GetComponent<SHR3>();

        base.Awake();
    }
}