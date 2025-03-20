using UnityEngine;

// Bat Flee State
public class BatFleeState : BatState
{
    public BatFleeState(BatStateMachine stateMachine, Bat bat) : base(stateMachine, bat) { }

    public override void EnterState()
    {
        // Bat begins fleeing
    }

    public override void UpdateState()
    {
        float distance = Vector2.Distance(bat.transform.position, bat.player.position);

        if (distance > bat.fleeDistance * 1.5f) // If the player is far enough, return to idle
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        // Move away from the player
        Vector3 direction = (bat.transform.position - bat.player.position).normalized;
        bat.transform.position += direction * bat.fleeSpeed * Time.deltaTime;
    }

    public override void ExitState() { }
}