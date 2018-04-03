
public class SHR3 : SHR
{
    public override void Awake()
    {
        yes_state = gameObject.GetComponent<SHK7>();
        no_state = gameObject.GetComponent<End>();

        base.Awake();
    }
}