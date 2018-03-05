
public class SHR2 : SHR
{ 
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<CPR4>();
        yes_state = gameObject.GetComponent<SHK5>();
        no_state = gameObject.GetComponent<End>();

        base.Awake();
    }
}

