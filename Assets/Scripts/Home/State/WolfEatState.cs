using UnityEngine;

public class WolfEatState : BaseWolfState
{
    public WolfEatState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.rb.linearVelocity = Vector2.zero;

        wolf.animator.SetBool("isWalking", false);
        wolf.animator.SetTrigger("isEating");
        
        wolf.ReduceHunger(10f);
        Debug.Log("Home: Wolf eats meat");
    }
}