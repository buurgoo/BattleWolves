using UnityEngine;

public class WolfEatState : BaseWolfState
{
    public WolfEatState(WolfHomeController wolf) : base(wolf) { }

    public override void EnterState()
    {
        wolf.rb.linearVelocity = Vector2.zero;

        wolf.animator.SetBool("isWalking", false);
        wolf.FeedingManager.OpenMenu();
        // Debug.Log("Home: Wolf eats meat");
    }

    public override void EndState()
    {
        wolf.FeedingManager.CloseMenu();
    }
}