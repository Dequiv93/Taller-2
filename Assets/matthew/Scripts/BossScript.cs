using UnityEngine;

public class BossScript : EnemyScript
{
    public float attackCooldown = 2f;
    private float cooldownTimer;

    void Update()
    {
        base.Update(); // Lógica de seguimiento normal del EnemyScript

        cooldownTimer -= Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= stoppingDistance && cooldownTimer <= 0f)
        {
            Attack();
            cooldownTimer = attackCooldown;
        }
    }

    void Attack()
    {
        Debug.Log("El jefe ataca al jugador!");
        // Aquí podrías lanzar un proyectil, hacer daño en área, activar animaciones, etc.
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        // Aquí puedes añadir efectos extra del jefe, como:
        Debug.Log("¡El jefe rugió al recibir daño!");
    }
}
