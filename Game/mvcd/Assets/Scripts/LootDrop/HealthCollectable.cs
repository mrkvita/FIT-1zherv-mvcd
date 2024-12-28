using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
   [SerializeField] private float healAmount;
   public GameObject healAnim;

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         GameObject anim = Instantiate(healAnim, transform.position, Quaternion.identity);
         HealthController playerHealth = collision.gameObject.GetComponent<HealthController>();
         playerHealth.Heal(healAmount);
         Destroy(gameObject);
         Destroy(anim, 2f);
      }
   }
}

