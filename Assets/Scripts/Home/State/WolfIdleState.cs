using UnityEngine;

public class WolfIdleState : BaseWolfState
{
    public WolfIdleState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.rb.linearVelocity = Vector2.zero;
        wolf.animator.SetBool("isWalking", false);
    }

    public override void UpdateState() { }
}