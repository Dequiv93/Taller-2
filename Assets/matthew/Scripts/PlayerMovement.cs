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
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    private Vector2 lastMoveDirection = Vector2.right; // �ltima direcci�n de ataque

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

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput.normalized; // Guarda la �ltima direcci�n de movimiento
        }
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.linearVelocity = velocity;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }

    public void TriggerAttack()
    {
        Vector2 attackPosition = (Vector2)attackPoint.position + lastMoveDirection * attackRange * 0.5f;

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPosition, new Vector2(attackRange, attackRange * 0.5f), 0f, enemyLayers);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            Debug.Log("Golpeado enemigo: " + enemyCollider.name);
            EnemyScript enemy = enemyCollider.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                // enemy.TakeDamage(10);  // Se activar� cuando el otro programador implemente la funci�n
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Vector2 attackPosition = (Vector2)attackPoint.position + lastMoveDirection * attackRange * 0.5f;

        Gizmos.matrix = Matrix4x4.TRS(attackPosition, Quaternion.identity, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(attackRange, attackRange * 0.5f, 1f));
    }
}
