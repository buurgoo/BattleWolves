using UnityEngine;

public class WolfBathTimeState : BaseWolfState
{
    private float bathTimer = 0f;
    private int bathSteps = 0;

    public WolfBathTimeState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.animator.SetBool("isWalking", false);
        wolf.animator.SetTrigger("isBathing");
        
        bathTimer = 0f;
        bathSteps = 0;

        // wolf.ReduceStinky(50f);
        Debug.Log("Home: Wolf takes a bath");
    }

    public override void UpdateState()
    {
        bathTimer += Time.deltaTime;

        if (bathTimer >= 1f && bathSteps < 5)
        {
            bathTimer -= 1f;
            bathSteps++;

            wolf.ReduceStinky(20f);
            if (bathSteps >= 5) wolf.ChangeState(WolfState.Idle);
        }
    }
}