using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;

    public void ShootFireball()
    {
        if (fireballPrefab == null || firePoint == null) return;

        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Fireball fireballScript = fireball.GetComponent<Fireball>();

        Vector2 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - firePoint.position).normalized;

        
        fireballScript.shooter = gameObject;
    }
}