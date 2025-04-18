using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private PlayerStateMachine stateMachine;

    private Animator animator;
    public float MoveSpeed => moveSpeed;
    public Vector2 MoveInput => moveInput;

    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    private Vector2 lastMoveDirection = Vector2.right; // Última dirección de ataque

    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<PlayerStateMachine>();
        animator = GetComponent<Animator>(); // obtiene el componente animator
    }

    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
        UpdateAnimation(); // actualiza el animator con movimiento
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput;

            // Corrige la dirección dominante para evitar diagonales raras
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                lastMoveDirection = new Vector2(Mathf.Sign(moveInput.x), 0);
            }
            else
            {
                lastMoveDirection = new Vector2(0, Mathf.Sign(moveInput.y));
            }
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

        Collider2D[] hitEnemies = Physics2D.OverlapCapsuleAll(attackPosition, new Vector2(attackRange, attackRange * 0.5f), 0f, enemyLayers);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            Debug.Log("Golpeado enemigo: " + enemyCollider.name);
            EnemyScript enemy = enemyCollider.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);  // Se activar� cuando el otro programador implemente la funci�n
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

    private void UpdateAnimation()
    {
        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
        animator.SetFloat("lastMoveX", lastMoveDirection.x);
        animator.SetFloat("lastMoveY", lastMoveDirection.y);
        animator.SetBool("isMoving", moveInput.magnitude > 0.1f); // Usa un umbral para evitar jitter
    }
}
