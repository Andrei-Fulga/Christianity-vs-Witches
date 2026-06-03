using UnityEngine;

public class WitchController : MonoBehaviour
{
    public GameObject[] spellPrefabs; // 0=Fire, 1=Water, 2=Earth, 3=Lightning
    public Transform castPoint;
    private Animator anim;
    
    // NEW: Control the random timing directly in the Unity Inspector!
    public float minTimeBetweenSpells = 5.0f;
    public float maxTimeBetweenSpells = 8.0f;
    
    private float attackTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        // Set the very first delay when the game starts
        attackTimer = Random.Range(minTimeBetweenSpells, maxTimeBetweenSpells);
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            CastRandomSpell();
            
            // Pick a new random time for the NEXT spell
            attackTimer = Random.Range(minTimeBetweenSpells, maxTimeBetweenSpells); 
        }
    }

    void CastRandomSpell()
    {
        int spellIndex = Random.Range(0, 4);
        anim.Play("Attack" + spellIndex); // Trigger specific elemental animation
        
        // Spawn the spell
        GameObject spell = Instantiate(spellPrefabs[spellIndex], castPoint.position, Quaternion.identity);
        spell.GetComponent<SpellProjectile>().spellType = (PlayerController.DefenseType)(spellIndex + 1);
    }
}