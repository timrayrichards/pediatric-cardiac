
public class SHK5 : SHK
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<SHR2>();
        next_state = gameObject.GetComponent<CPR6>();

        base.Awake();
    }
}