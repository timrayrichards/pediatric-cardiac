
public class SHK3 : SHK
{
    public override void Awake()
    {
        next_state = gameObject.GetComponent<CPR4>(); 
       
        base.Awake();
    }
}
