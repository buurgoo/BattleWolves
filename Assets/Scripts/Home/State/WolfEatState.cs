using UnityEngine;

public class WolfEatState : BaseWolfState
{
    public WolfEatState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.ReduceHunger(10f);
        Debug.Log("Home: Wolf eats meat");
    }
}