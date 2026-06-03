using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum DefenseType { None, Fire, Water, Earth, Lightning }
    public DefenseType currentDefense = DefenseType.None;
    
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Called by the Card Menu Gaze Buttons (1=Fire, 2=Water, 3=Earth, 4=Lightning)
    public void PlayDefenseCard(int typeIndex)
    {
        currentDefense = (DefenseType)typeIndex;
        anim.Play("Defense"); // Trigger your defense animation
        Debug.Log("Player actively defending against: " + currentDefense);
    }

    public void PlayAttackCard()
    {
        anim.Play("Attack"); // Trigger your attack animation
        FindObjectOfType<GameManager>().DamageWitch(1);
    }
}