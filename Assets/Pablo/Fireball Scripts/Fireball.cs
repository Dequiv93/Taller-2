using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction; // Should be normalized before setting

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = direction * speed;
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}