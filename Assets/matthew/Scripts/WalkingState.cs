using UnityEngine;

public class WalkingState : PlayerState
{
    public WalkingState(PlayerStateMachine stateMachine, PlayerMovement player) : base(stateMachine, player) { }

    public override void EnterState() { }

    public override void UpdateState()
    {
        player.SetVelocity(player.MoveInput * player.MoveSpeed); // apply movement

        if (player.MoveInput.magnitude == 0) //if no input, switch to idle state
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    public override void ExitState() { } // nothing special to do when exiting the state
}
