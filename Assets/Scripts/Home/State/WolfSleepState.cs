using UnityEngine;

public class WolfSleepState : BaseWolfState
{
    private float sleepTimer = 0f;

    public WolfSleepState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.animator.SetBool("isWalking", false);
        wolf.animator.SetBool("isSleeping", true);

        wolf.rb.linearVelocity = Vector2.zero;
        sleepTimer = 0f;

        // wolf.ReduceSleepy(15f);
        Debug.Log("Home: Wolf sleeps");
    }

    public override void UpdateState()
    {
        sleepTimer += Time.deltaTime;

        if (sleepTimer >= 1f)
        {
            sleepTimer -= 1f;
            wolf.ReduceSleepy(2f);
        }
    }

    public override void EndState()
    {
        wolf.animator.SetBool("isSleeping", false);
    }
}