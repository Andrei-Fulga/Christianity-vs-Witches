using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    public float speed = 6f;
    private SpellType type;
    private Animator anim;

    void Awake() { anim = GetComponent<Animator>(); }

    public void Setup(SpellType incomingType)
    {
        type = incomingType;
        
        // Play the clip name exactly as you named them in the Animation window
        switch (type)
        {
            case SpellType.Fire: anim.Play("Spell_Fire"); break;
            case SpellType.Water: anim.Play("Spell_Water"); break;
            case SpellType.Earth: anim.Play("Spell_Earth"); break;
            case SpellType.Lightning: anim.Play("Spell_Lightning"); break;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Assuming Player is at X = -7
        if (transform.position.x <= -7.5f)
        {
            GameManager.Instance.ReceiveWitchSpell(type);
            Destroy(gameObject);
        }
    }
}