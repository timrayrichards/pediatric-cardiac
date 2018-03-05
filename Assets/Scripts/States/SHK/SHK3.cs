
public class SHK3 : SHK
{
    public override void Awake()
    {
        prev_state = gameObject.GetComponent<SHR1>();
        next_state = gameObject.GetComponent<CPR4>(); 
       
        base.Awake();
    }
}
