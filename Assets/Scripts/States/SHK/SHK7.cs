
public class SHK7 : SHK
{
    public override void Awake()
    {
        next_state = gameObject.GetComponent<CPR8>();

        base.Awake();
    }
}