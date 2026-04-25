using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour
{
    public GameObject spellPrefab;
    public Transform castPoint;
    public Animator witchAnim;

    void Start() { StartCoroutine(AttackRoutine()); }

    IEnumerator AttackRoutine()
    {
        while (GameManager.Instance.gameActive)
        {
            // Wait between attacks
            yield return new WaitForSeconds(Random.Range(3.5f, 5.5f));

            // Pick a random element (1=Fire, 2=Water, 3=Earth, 4=Lightning)
            SpellType nextSpell = (SpellType)Random.Range(1, 5);

            // 1. Play the specific color-burst animation (The "Tell")
            witchAnim.SetTrigger(nextSpell.ToString());

            // 2. Wait for the channeling animation to reach the "blast" moment
            yield return new WaitForSeconds(0.9f);

            // 3. Fire the projectile
            GameObject bolt = Instantiate(spellPrefab, castPoint.position, Quaternion.identity);
            bolt.GetComponent<SpellProjectile>().Setup(nextSpell);
        }
    }
}