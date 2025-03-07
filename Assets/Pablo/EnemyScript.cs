using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 3f; // Speed of the enemy's movement
    public float stoppingDistance = 1.5f; // Distance at which the enemy stops following the player
    public Transform player; // Reference to the player's position
    public float chasingDistance;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > chasingDistance) { return; }

        if (player != null && distance > stoppingDistance)
        {
            // Get the direction vector from the enemy to the player
            Vector3 direction = player.position - transform.position;

            // Only move along the X or Y axis, whichever is closest
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Move horizontally towards the player
                if (direction.x > 0)
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
            }
            else
            {
                // Move vertically towards the player
                if (direction.y > 0)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
            }



            // If the enemy is within stopping distance, stop moving
            if (direction.magnitude <= stoppingDistance)
            {
                // Optionally, add behavior later down the line for when the enemy stops (like attacking, etc.)
            }
        }
    }
}