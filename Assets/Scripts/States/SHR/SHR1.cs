
public class SHR1 : SHR
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<CPR1>();
        yes_state = gameObject.GetComponent<SHK3>();
        no_state = gameObject.GetComponent<CPR10>();

        base.Awake();
    }
}
