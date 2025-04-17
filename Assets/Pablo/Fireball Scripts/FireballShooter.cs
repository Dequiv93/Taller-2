using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint; 

    public void ShootFireball()
    {
        if (fireballPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Missing fireballPrefab or firePoint!");
            return;
        }

        
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        Vector2 shootDirection = firePoint.right; 
        fireball.GetComponent<Fireball>().direction = shootDirection.normalized;
    }
}