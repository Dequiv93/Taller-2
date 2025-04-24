using UnityEngine;

public class BossScript : EnemyScript
{
    public float attackCooldown = 2f;
    private float cooldownTimer;

    void Update()
    {
        base.Update(); // L�gica de seguimiento normal del EnemyScript

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
        // Aqu� podr�as lanzar un proyectil, hacer da�o en �rea, activar animaciones, etc.
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        // Aqu� puedes a�adir efectos extra del jefe, como:
        Debug.Log("�El jefe rugi� al recibir da�o!");
    }
}
