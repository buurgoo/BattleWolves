using UnityEngine;

public abstract class BaseWolfState
{
    protected WolfHomeController wolf;

    protected BaseWolfState(WolfHomeController wolf)
    {
        this.wolf = wolf;
    }

    public virtual void EnterState() { }
    
    public virtual void UpdateState() { }
    
    public virtual void FixedUpdateState() { }
    
    public virtual void EndState() { }
}