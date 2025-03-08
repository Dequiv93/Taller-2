using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState IdleState { get; private set; } // reference to the idle state
    public PlayerState WalkingState { get; private set; }// reference to the walking state
    private PlayerState currentState; 
    private PlayerMovement player;

    void Awake()
    {
        // Initialize the states
        player = GetComponent<PlayerMovement>();
        IdleState = new IdleState(this, player);
        WalkingState = new WalkingState(this, player);
    }

    void Start()
    {
        currentState = IdleState; // start in the idle state
        currentState.EnterState();
    }

    void Update()
    {
        currentState.UpdateState(); // update the current state
    }

    // Function to change the current state
    public void ChangeState(PlayerState newState)
    {
        currentState.ExitState(); // exit the current state
        currentState = newState; // change to the new state
        currentState.EnterState(); // enter the new state
    }
}
