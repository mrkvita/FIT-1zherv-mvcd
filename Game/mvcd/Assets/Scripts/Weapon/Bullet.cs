using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public GameObject hitEffect;
   [SerializeField] private float dmg;
   [SerializeField] private float critChance;
   [SerializeField] private float critMultiplier;
   private void OnCollisionEnter2D(Collision2D collision)
   {
      GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
      if (collision.gameObject.tag == "Enemy")
      {
         var HealthController = collision.gameObject.GetComponent<HealthController>();
         if (HealthController != null)
         {
            float rand = Random.Range(0f, 100f);
            if (rand <= critChance)
            {
               dmg = critMultiplier * dmg;
            }
            HealthController.TakeDamage(dmg);
         }
      }
      Destroy(effect, 1f);
   }
    
}
