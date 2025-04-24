using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel != null)
            {
                
                panel.SetActive(!panel.activeSelf);
            }
        }
    }
}
