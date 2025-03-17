using UnityEngine;

// Enemy Idle State
public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyStateMachine stateMachine, EnemyScript enemy) : base(stateMachine, enemy) { }

    public override void EnterState()
    {
        // Enemy does nothing while idle
    }

    public override void UpdateState()
    {
        float distance = Vector2.Distance(enemy.transform.position, enemy.player.position);
        if (distance <= enemy.chasingDistance)
        {
            stateMachine.ChangeState(stateMachine.FollowState);
        }
    }

    public override void ExitState() { }
}