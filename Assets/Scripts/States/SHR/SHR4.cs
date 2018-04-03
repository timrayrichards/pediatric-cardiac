
public class SHR4 : SHR
{
    public override void Awake()
    {
        yes_state = gameObject.GetComponent<SHK5>(); // or SHK7
        no_state = gameObject.GetComponent<CPR11>();

        base.Awake();
    }
}
