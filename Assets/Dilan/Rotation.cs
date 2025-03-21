using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetRotation(180f);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SetRotation(-90f);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetRotation(0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetRotation(90f);
        }
    }

    void SetRotation(float zAngle)
    {
        transform.rotation = Quaternion.Euler(0, 0, zAngle);
    }
}

