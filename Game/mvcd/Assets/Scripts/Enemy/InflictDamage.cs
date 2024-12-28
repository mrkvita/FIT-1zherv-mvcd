using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float timeBetweenDamage;
    private HashSet<GameObject> invincibleFrom = new HashSet<GameObject>(); // Tracks attackers the player is invincible to
 

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            if (healthController == null)
            {
                return;
            }
            // The player is now not invincible from all the 
            // walkers but rather the times of invincibility are
            // calcluated for each walker respecivily 
            if (!invincibleFrom.Contains(gameObject))
            {
                healthController.TakeDamage(damage);
                StartCoroutine(DontTakeCoroutine(timeBetweenDamage, gameObject));
            }
        }
    }
    
    private IEnumerator DontTakeCoroutine(float duration, GameObject attacker)
       {
            invincibleFrom.Add(attacker);
            yield return new WaitForSeconds(duration);
            invincibleFrom.Remove(attacker);
       }
}
