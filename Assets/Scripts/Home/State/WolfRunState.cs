using UnityEngine;

public class WolfRunState : BaseWolfState
{
    private float speed = 10f;

    public WolfRunState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        //wolf.animator.SetBool("isRunning", true);
    }

    public override void FixedUpdateState()
    {
        float move = wolf.GetMove();
        wolf.rb.linearVelocity = new Vector2(move * speed, 0f);
    }

    public override void EndState()
    {
        wolf.rb.linearVelocity = Vector2.zero;
        //wolf.animator.SetBool("isRunning", false);
    }
}