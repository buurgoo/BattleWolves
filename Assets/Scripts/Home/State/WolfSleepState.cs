using UnityEngine;

public class WolfSleepState : BaseWolfState
{
    public WolfSleepState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.ReduceSleepy(15f);
        Debug.Log("Home: Wolf sleeps");
    }
}