using UnityEngine;

// Enemy Follow State
public class EnemyFollowState : EnemyState
{
    public EnemyFollowState(EnemyStateMachine stateMachine, EnemyScript enemy) : base(stateMachine, enemy) { }

    public override void EnterState()
    {
        // Enemy starts moving toward the player
    }

    public override void UpdateState()
    {
        float distance = Vector2.Distance(enemy.transform.position, enemy.player.position);

        if (distance > enemy.chasingDistance)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        if (distance > enemy.stoppingDistance)
        {
            Vector3 direction = (enemy.player.position - enemy.transform.position).normalized;
            enemy.transform.position += direction * enemy.speed * Time.deltaTime;
        }
    }

    public override void ExitState() { }
}