using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject shooter;  // Quién disparó la bola
    public float speed = 5f;

    private Rigidbody2D rb;
    private Transform target;  // El objetivo (jugador)

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;  // Busca el jugador
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;  // Calcula la dirección hacia el jugador
            rb.linearVelocity = direction * speed;  // Mueve la bola hacia el jugador
        }

        Destroy(gameObject, 5f);  // Destruir la bola después de 5 segundos
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si la bola de fuego toca al jugador y no al Boss que la dispara
        if (collision.CompareTag("Player"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.LoseHp(1);  // Aplica daño al jugador
            }

            // Destruir la bola después de colisionar con el jugador
            Destroy(gameObject);
        }
        // Si la bola colisiona con cualquier otro objeto (por ejemplo, paredes), no la destruimos
    }
}