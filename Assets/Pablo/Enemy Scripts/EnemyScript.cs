using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public float speed = 3f; // Enemy movement speed
    public float stoppingDistance = 1.5f; // Distance to stop following player
    public float chasingDistance = 5f; // Maximum chase range
    public int health = 20; // Enemy's health
    public int sceneBuildIndex;
    public Transform player; // Reference to the player

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    protected virtual void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > chasingDistance) return;

        if (distance > stoppingDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public virtual void TakeDamage(int damage)
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
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

    }
}