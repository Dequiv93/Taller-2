using UnityEngine;

// Bat State Machine
public class BatStateMachine : MonoBehaviour
{
    public BatState IdleState { get; private set; }
    public BatState FleeState { get; private set; }
    private BatState currentState;
    private Bat bat;

    void Awake()
    {
        bat = GetComponent<Bat>();
        IdleState = new BatIdleState(this, bat);
        FleeState = new BatFleeState(this, bat);
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

    public void ChangeState(BatState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}