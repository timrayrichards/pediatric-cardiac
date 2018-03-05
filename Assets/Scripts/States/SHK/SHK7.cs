
public class SHK7 : SHK
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<SHR3>();
        next_state = gameObject.GetComponent<CPR8>();

        base.Awake();
    }
}