
public class CPR6 : CPR
{
    public override void Awake()
    {
        next_state = gameObject.GetComponent<SHR3>();

        base.Awake();
    }
}