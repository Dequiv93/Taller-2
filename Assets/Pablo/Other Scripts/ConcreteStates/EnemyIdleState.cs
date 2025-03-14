using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        // Set a random target position for the enemy to move to
        _targetPos = GetRandomPointInCircle();
        Debug.Log("Entered Idle State. Target position: " + _targetPos);
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exiting Idle State.");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        // Check if the enemy is aggroed, if so, change to chase state
        if (enemy.IsAggroed)
        {
            Debug.Log("Enemy is aggroed! Switching to Chase State.");
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        // Move the enemy towards the target position
        _direction = (_targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(_direction * enemy.RandomMovementSpeed);

        // If the enemy reached the target position, select a new random target
        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f)
        {
            _targetPos = GetRandomPointInCircle();
            Debug.Log("Target reached! New target position: " + _targetPos);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private Vector3 GetRandomPointInCircle()
    {
        // Generate a random point within a circle around the enemy's current position
        Vector3 randomPoint = enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.RandomMovementRange;
        Debug.Log("New target position: " + randomPoint);
        return randomPoint;
    }
}
