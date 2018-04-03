
public class SHR5 : SHR
{
    public override void Awake()
    {
        yes_state = gameObject.GetComponent<SHK5>(); // or SHK7
        no_state = gameObject.GetComponent<End>(); 

        base.Awake();
    }
}