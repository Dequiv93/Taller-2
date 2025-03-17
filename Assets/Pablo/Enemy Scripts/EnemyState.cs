using UnityEngine;

// Base Enemy State Class
public abstract class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected EnemyScript enemy;

    public EnemyState(EnemyStateMachine stateMachine, EnemyScript enemy)
    {
        this.stateMachine = stateMachine;
        this.enemy = enemy;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}