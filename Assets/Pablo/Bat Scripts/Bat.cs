using UnityEngine;

// Bat Script
public class Bat : MonoBehaviour
{
    public float fleeSpeed = 2f;  // Speed at which the bat moves away
    public float fleeDistance = 4f; // Distance at which the bat starts fleeing
    public Transform player;

    private BatStateMachine stateMachine;

    void Awake()
    {
        stateMachine = GetComponent<BatStateMachine>();

        // Auto-assign player if not set
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("No Player found! Assign Player manually.");
            }
        }
    }

    void Start()
    {
        if (stateMachine == null)
        {
            Debug.LogError("BatStateMachine is missing from the Bat GameObject!");
            return;
        }

        stateMachine.ChangeState(stateMachine.IdleState);
    }
}