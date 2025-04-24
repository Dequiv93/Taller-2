using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHp;
    public int playerMaxHp = 5;

    private void Start()
    {
        playerHp = playerMaxHp;
    }

    public void LoseHp(int amount)
    {
        playerHp -= amount;
        Debug.Log("El jugador recibió daño. Vida restante: " + playerHp);

        if (playerHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        Destroy(gameObject);
    }
}
