using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elements")]
    public GameObject cardMenuPanel;
    public Image playerHealthUI;
    public Image witchHealthUI;
    public Sprite[] healthBarSprites; // Assign 7 sprites (0 to 6)

    [Header("Animators")]
    public Animator playerAnim;
    public Animator witchAnim;

    [Header("Game State")]
    public int playerHealth = 6;
    public int witchHealth = 6;
    public SpellType activePlayerDefense = SpellType.None;
    public bool gameActive = true;

    void Awake() { Instance = this; }

    public void OpenCardMenu() { if(gameActive) cardMenuPanel.SetActive(true); }
    public void CloseCardMenu() { cardMenuPanel.SetActive(false); }

    public void PlayAttackCard()
    {
        if (!gameActive) return;
        playerAnim.SetTrigger("Attack");
        witchHealth--;
        UpdateUI();
        CloseCardMenu();
    }

    public void PlayDefenseCard(int typeIndex)
    {
        if (!gameActive) return;
        activePlayerDefense = (SpellType)typeIndex;
        playerAnim.SetTrigger("Defend");
        CloseCardMenu();
    }

    public void ReceiveWitchSpell(SpellType incomingType)
    {
        if (activePlayerDefense == incomingType)
        {
            Debug.Log("PERFECT BLOCK!");
        }
        else
        {
            Debug.Log("HIT! Element: " + incomingType);
            playerHealth--;
            UpdateUI();
        }
        activePlayerDefense = SpellType.None; // Defense resets after spell passes
    }

    void UpdateUI()
    {
        playerHealth = Mathf.Clamp(playerHealth, 0, 6);
        witchHealth = Mathf.Clamp(witchHealth, 0, 6);

        playerHealthUI.sprite = healthBarSprites[playerHealth];
        witchHealthUI.sprite = healthBarSprites[witchHealth];

        if (witchHealth <= 0) EndGame("Victory! The Witch is defeated.");
        if (playerHealth <= 0) EndGame("Defeat... You have fallen.");
    }

    void EndGame(string message)
    {
        Debug.Log(message);
        gameActive = false;
        FindObjectOfType<WitchController>().StopAllCoroutines();
    }
}