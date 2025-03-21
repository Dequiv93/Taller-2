using UnityEngine;

public class BlockingState : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }
        if (Input.GetKeyUp(KeyCode.Q))
        {

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
