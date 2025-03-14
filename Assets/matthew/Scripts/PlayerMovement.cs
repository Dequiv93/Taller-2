using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private PlayerStateMachine stateMachine;



    public float MoveSpeed => moveSpeed; //Returns move speed (read-only)
    public Vector2 MoveInput => moveInput; //Returns the current movement input (read-only)

    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform attackPoint; //Reference to the attack point
    [SerializeField] private float attackRange = 0.5f; //Attack range
    [SerializeField] private LayerMask enemyLayer; //Layer mask for the enemy layer

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    void Update()
    {
        //apply movement based on input and speed
        rb.linearVelocity = moveInput * moveSpeed;
    }

    // Called automatically by Unity's Input System when movement input changes
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); //Read and store movement input
    }

    // Allows other scripts (like state machine) to modify the player's velocity
    public void SetVelocity(Vector2 velocity)
    {
        rb.linearVelocity = velocity; //Directly set the Rigidbody velocity
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
        // Detect enemies in attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Loop through detected enemies
        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Commented out to avoid errors since the Enemy class doesn't exist yet
            // Enemy enemy = enemyCollider.GetComponent<Enemy>(); // Get the Enemy script
            // if (enemy != null)
            // {
            //     enemy.TakeDamage(10); // Call TakeDamage() function
            // }

            // Just log for now to confirm detection
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
