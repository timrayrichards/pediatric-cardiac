
public class SHR4 : SHR
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<CPR10>();
        yes_state = gameObject.GetComponent<SHK5>(); // or SHK7
        no_state = gameObject.GetComponent<CPR11>();

        base.Awake();
    }
}
