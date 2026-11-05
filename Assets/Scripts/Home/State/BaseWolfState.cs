public class BaseWolfState
{
    protected WolfController wolf;

    protected BaseWolfState(WolfController wolf)
    {
        this.wolf = wolf;
    }

    public virtual void EnterState() { }
    
    public virtual void UpdateState() { }
    
    public virtual void FixedUpdateState() { }
    
    public virtual void EndState() { }
}