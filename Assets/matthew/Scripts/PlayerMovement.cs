using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private PlayerStateMachine stateMachine;

    public float MoveSpeed => moveSpeed;
    public Vector2 MoveInput => moveInput;

    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform attackPoint; // Reference to the attack point
    [SerializeField] private float attackRange = 0.5f; // Attack range

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.linearVelocity = velocity;
    }

    // Attack input from Unity Input System
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }

    public void TriggerAttack()
    {
        // Detect enemies in attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Get the Enemy script
            EnemyScript enemy = enemyCollider.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(1); // Deal damage
            }

            Debug.Log("Hit enemy: " + enemyCollider.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
