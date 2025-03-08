using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public float MoveSpeed => moveSpeed; //Returns move speed (read-only)
    public Vector2 MoveInput => moveInput; //Returns the current movement input (read-only)

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
