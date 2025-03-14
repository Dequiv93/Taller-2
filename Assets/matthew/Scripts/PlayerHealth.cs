using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHp;
    public int playermaxHp;
    public bool reciveDamage = true;



    private void start()
    {
        playerHp = playermaxHp;
    }

   

    public void LoseHp(int amount)
    {

        playerHp -= amount;
        if (playerHp <= 0)
        {
            Destroy(gameObject);
        }
       
    }


}
