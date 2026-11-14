using UnityEngine;

public class WolfBathTimeState : BaseWolfState
{
    public WolfBathTimeState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.ReduceStinky(50f);
        Debug.Log("Home: Wolf takes a bath");
    }
}