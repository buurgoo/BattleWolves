using UnityEngine;

public class WolfSleepState : BaseWolfState
{
    public WolfSleepState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.animator.SetBool("isWalking", false);
        wolf.animator.SetBool("isSleeping", true);

        wolf.rb.linearVelocity = Vector2.zero;
        wolf.ReduceSleepy(15f);
        Debug.Log("Home: Wolf sleeps");
    }

    public override void EndState()
    {
        wolf.animator.SetBool("isSleeping", false);
    }
}