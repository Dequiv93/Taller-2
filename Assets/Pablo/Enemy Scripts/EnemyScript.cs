using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 3f; // Enemy movement speed
    public float stoppingDistance = 1.5f; // Distance to stop following player
    public float chasingDistance = 5f; // Maximum chase range
    public int health = 20; // Enemy's health

    public Transform player; // Reference to the player

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null) return; // Ensure player exists

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > chasingDistance) return; // Stop if too far away

        if (distance > stoppingDistance)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // Function to receive damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage! Health left: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Function to destroy the enemy when health reaches zero
    private void Die()
    {
        Debug.Log(gameObject.name + " has been defeated!");
        Destroy(gameObject);
    }
}