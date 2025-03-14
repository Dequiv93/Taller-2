using UnityEngine;

public class AttackState : PlayerState
{
    private float attackDuration = 0.3f;
    private float attackTimer;

    public AttackState(PlayerStateMachine stateMachine, PlayerMovement player)
        : base(stateMachine, player) { }

    public override void EnterState()
    {
        attackTimer = attackDuration;// Reset the attack timer
        player.SetVelocity(Vector2.zero);// Stop the player
        player.TriggerAttack();// Trigger the attack animation
    }

    public override void UpdateState()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            //return to idle or walking after atack
            if(player.MoveInput.magnitude > 0)
            {
                stateMachine.ChangeState(stateMachine.WalkingState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }
    public override void ExitState() 
    { 
    }
}
