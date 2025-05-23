using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int enemyDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Shield"))
        {
            return;
        }

        playerHealth.LoseHp(enemyDamage);
    }
}
