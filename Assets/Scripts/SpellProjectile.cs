using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    public float speed = 0.13974f; 
    public PlayerController.DefenseType spellType;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            
            // Safety check: Make sure it actually found Constantine
            if (player != null) 
            {
                if (player.currentDefense == spellType)
                {
                    Debug.Log("Spell Blocked! Player survives.");
                    player.currentDefense = PlayerController.DefenseType.None; 
                    player.GetComponent<Animator>().Play("Idle"); 
                }
                else
                {
                    Debug.Log("Player Hit! Wrong or no defense.");
                    FindObjectOfType<GameManager>().DamagePlayer(1);
                }
            }
            Destroy(gameObject);
        }
    }
}