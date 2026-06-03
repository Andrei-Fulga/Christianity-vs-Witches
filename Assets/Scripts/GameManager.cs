using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 6;
    public int witchHealth = 6;

    public Sprite[] healthBarImages; 
    
    // CHANGED to SpriteRenderer to perfectly match your project setup!
    public SpriteRenderer playerHealthUI;
    public SpriteRenderer witchHealthUI;

    public void DamagePlayer(int amount)
    {
        playerHealth -= amount;
        if (playerHealth < 0) playerHealth = 0;
        UpdateHealthBars();
        if (playerHealth == 0) Debug.Log("Witch Wins!");
    }

    public void DamageWitch(int amount)
    {
        witchHealth -= amount;
        if (witchHealth < 0) witchHealth = 0;
        UpdateHealthBars();
        if (witchHealth == 0) Debug.Log("Player Wins!");
    }

    void UpdateHealthBars()
    {
        // Safety checks added so it never crashes!
        if (playerHealthUI != null) playerHealthUI.sprite = healthBarImages[playerHealth];
        if (witchHealthUI != null) witchHealthUI.sprite = healthBarImages[witchHealth];
    }
}