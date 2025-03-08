using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(PlayerStateMachine stateMachine, PlayerMovement player) : base(stateMachine, player) { }

    // Called when the state is entered(idle)
    public override void EnterState()
    {
        player.SetVelocity(Vector2.zero); // Stop the player from moving
    }

    // Called every frame to check if the player is moving
    public override void UpdateState()
    {
        if (player.MoveInput.magnitude > 0) // if theres input, switch to walking state
        {
            stateMachine.ChangeState(stateMachine.WalkingState);
        }
    }

    public override void ExitState() { } // nothing special to do when exiting the state
}
