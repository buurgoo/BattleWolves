using UnityEngine;

public class WolfController
{
    private BaseWolfState activeState;
    private WolfState currentState;

    public void ChangeState(WolfState newState)
    {
        if (currentState == newState && activeState != null) return;

        activeState?.EndState();
        currentState = newState;

        activeState = newState switch // TODO: modify when states will be ready
        {
            WolfState.Idle     => new WolfIdleState(this),
            WolfState.Walk     => new WolfWalkState(this),
            WolfState.Eat      => new WolfEatState(this),
            WolfState.Sleep    => new WolfSleepState(this),
            WolfState.BathTime => new WolfBathTimeState(this),
            _                  => new WolfIdleState(this)
        };

        activeState.EnterState();
    }

    private void Update()
    {
        activeState?.UpdateState();
    }

    private void FixedUpdate()
    {
        activeState?.FixedUpdateState();
    }
}