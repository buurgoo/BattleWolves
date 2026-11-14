using UnityEngine;

public class WolfIdleState : BaseWolfState
{
    public WolfIdleState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        // TODO: added Idle animation
        wolf.rb.linearVelocity = Vector2.zero;
    }

    public override void UpdateState() { }
}