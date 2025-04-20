using UnityEngine;

public class AttackState : PlayerState
{
    private float attackDuration = 0.3f;
    private float attackTimer;

    public AttackState(PlayerStateMachine stateMachine, PlayerMovement player)
        : base(stateMachine, player) { }

    public override void EnterState()
    {
        attackTimer = attackDuration; // Reset the attack timer

        player.SetVelocity(Vector2.zero); // Stop the player

        //  Activar la animación del ataque según la dirección
        player.Animator.SetTrigger("attack");

        //  Detectar colisiones o aplicar daño
        player.TriggerAttack();
    }

    public override void UpdateState()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            // Volver al estado correspondiente
            if (player.MoveInput.magnitude > 0.1f)
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
        // Puedes limpiar el trigger si es necesario:
        // player.Animator.ResetTrigger("attack");
    }
}
