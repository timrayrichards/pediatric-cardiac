
public class SHK5 : SHK
{
    public override void Awake()
    {
        next_state = gameObject.GetComponent<CPR6>();

        base.Awake();
    }
}