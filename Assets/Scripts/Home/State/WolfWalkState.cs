using UnityEngine;

public class WolfWalkState : BaseWolfState
{
    private float speed = 5f;

    public WolfWalkState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        // TODO: added walk animation
    }

    public override void FixedUpdateState()
    {
        float move = wolf.moveAction.ReadValue<float>();
        wolf.rb.linearVelocity = new Vector2(move * speed, 0f);    
    }

    public override void EndState()
    {
        wolf.rb.linearVelocity = Vector2.zero;
    }
}