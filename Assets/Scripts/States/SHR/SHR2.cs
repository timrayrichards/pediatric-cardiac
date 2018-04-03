
public class SHR2 : SHR
{ 
    public override void Awake()
    {
        yes_state = gameObject.GetComponent<SHK5>();
        no_state = gameObject.GetComponent<End>();

        base.Awake();
    }
}

