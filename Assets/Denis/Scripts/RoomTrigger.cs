using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public AudioClip suspenseSound; // Arrasta aqui tu clip de sonido
    private AudioSource audioSource;
    public Light[] lights2D; // referencia a la luz de la antorcha

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = suspenseSound;

        // Asignar luces manualmente (ejemplo)
        lights2D = new Light[7];
        lights2D[0] = GameObject.Find("TorchLight1").GetComponent<Light>();
        lights2D[1] = GameObject.Find("TorchLight2").GetComponent<Light>();
        lights2D[2] = GameObject.Find("TorchLight3").GetComponent<Light>();
        lights2D[3] = GameObject.Find("TorchLight4").GetComponent<Light>();
        lights2D[4] = GameObject.Find("TorchLight5").GetComponent<Light>();
        lights2D[5] = GameObject.Find("TorchLight6").GetComponent<Light>();
        lights2D[6] = GameObject.Find("TorchLight7").GetComponent<Light>();


        // Asegurase que todas las luces esten apagadas al principio 
        foreach (Light light in lights2D)
        {
            light.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegurarse de que el personaje tenga la etiqueta Player
        {
            PlaySuspenseSound();
            ActivateLights2D();
            // Aqui se agrega la logica para avisar al minotauro
        }
    }

    // Update is called once per frame
    void PlaySuspenseSound()
    {
        audioSource.PlayOneShot(suspenseSound);
    }

    void ActivateLights2D()
    {
        foreach (Light light in lights2D)
        {
            light.enabled = true; // activa la luz de la antorcha
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DesactivateLights2D();
        }
    }

    void DesactivateLights2D()
    {
        foreach (Light light in lights2D)
        {
            light.enabled = false; // Desactiva la luz de las anotorchas
        }
    }
}
