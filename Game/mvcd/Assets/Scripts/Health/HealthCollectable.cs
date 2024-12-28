using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
   [SerializeField] private float healAmount;

   private void OnTriggerEnter2D(Collider2D collision)
   {
      Debug.Log("Collided with " + collision.gameObject.name);
      
      if (collision.gameObject.CompareTag("Player"))
      {
         Debug.Log("collided with player");
         HealthController playerHealth = collision.gameObject.GetComponent<HealthController>();
         playerHealth.Heal(healAmount);
         Destroy(gameObject);
      }
   }
}

