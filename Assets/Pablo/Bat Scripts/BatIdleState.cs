using UnityEngine;

// Bat Idle State
public class BatIdleState : BatState
{
    public BatIdleState(BatStateMachine stateMachine, Bat bat) : base(stateMachine, bat) { }

    public override void EnterState()
    {
        // Bat remains still
    }

    public override void UpdateState()
    {
        float distance = Vector2.Distance(bat.transform.position, bat.player.position);
        if (distance <= bat.fleeDistance)
        {
            stateMachine.ChangeState(stateMachine.FleeState);
        }
    }

    public override void ExitState() { }
}