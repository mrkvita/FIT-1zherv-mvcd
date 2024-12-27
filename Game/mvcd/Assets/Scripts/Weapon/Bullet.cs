using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public GameObject hitEffect; 
   private void OnCollisionEnter2D(Collision2D collision)
   {
      GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
      if (collision.gameObject.tag == "Enemy")
      {
         var HealthController = collision.gameObject.GetComponent<HealthController>();
         if (HealthController != null)
         {
            float dmg = Random.Range(25f, 35f);
            HealthController.TakeDamage(dmg);
         }
      }
      Destroy(effect, 1f);
   }
    
}