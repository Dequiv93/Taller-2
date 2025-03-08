using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerMovement player;

    //Constructor to initialize the state with the state machine and player reference
    public PlayerState(PlayerStateMachine stateMachine, PlayerMovement player)
    {
        this.stateMachine = stateMachine;
        this.player = player;
    }
    //Methods that each state must implement
    public abstract void EnterState(); //Called when the state is entered
    public abstract void UpdateState(); // Called every frame while in this state
    public abstract void ExitState();// Called when the state is exited
}
