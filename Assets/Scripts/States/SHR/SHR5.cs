
public class SHR5 : SHR
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<CPR11>();
        yes_state = gameObject.GetComponent<SHK5>(); // or SHK7
        no_state = null; //TODO: End

        base.Awake();
    }
}