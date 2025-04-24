using UnityEngine;

public class BossScript : EnemyScript
{
    [SerializeField] private FireballShooter fireballShooter;
    [SerializeField] private float shootInterval = 2f;

    private float shootTimer;

    void Start()
    {
        base.Start(); // Inicializa lo del EnemyScript
        shootTimer = shootInterval;
    }

    void Update()
    {
        base.Update(); // Ejecuta la lógica de perseguir al jugador

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            ShootFireball();
            shootTimer = shootInterval;
        }
    }

    void ShootFireball()
    {
        if (fireballShooter != null)
        {
            // La dirección se puede ajustar según la posición del jugador
            Vector2 dir = (player.position - transform.position).normalized;
            fireballShooter.firePoint.right = dir; // Apunta hacia el jugador
            fireballShooter.ShootFireball();
        }
    }

    public new void TakeDamage(int damage)
    {
        base.TakeDamage(damage); // Reutiliza la lógica de EnemyScript
        // Puedes agregar efectos especiales del boss aquí si quieres
    }
}
