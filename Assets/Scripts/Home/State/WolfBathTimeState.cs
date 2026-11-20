using UnityEngine;

public class WolfBathTimeState : BaseWolfState
{
    public WolfBathTimeState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.animator.SetBool("isWalking", false);
        wolf.animator.SetTrigger("isBathing");
        
        wolf.ReduceStinky(50f);
        Debug.Log("Home: Wolf takes a bath");
    }
}