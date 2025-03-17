using UnityEngine;

// Enemy State Machine
public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState IdleState { get; private set; }
    public EnemyState FollowState { get; private set; }
    private EnemyState currentState;
    private EnemyScript enemy;

    void Awake()
    {
        enemy = GetComponent<EnemyScript>();
        IdleState = new EnemyIdleState(this, enemy);
        FollowState = new EnemyFollowState(this, enemy);
    }

    void Start()
    {
        currentState = IdleState;
        currentState.EnterState();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}