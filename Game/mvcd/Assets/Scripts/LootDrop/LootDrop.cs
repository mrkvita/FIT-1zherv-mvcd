using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootDrop : MonoBehaviour
{
   [SerializeField] private GameObject healPrefab;
   [SerializeField] private GameObject weaponPrefab;
   [SerializeField] private float dropRate;
   [SerializeField] private float shotgunSpawnRate;
   [SerializeField] private float healSpawnRate;
   public KeyCode openKey = KeyCode.E;
   public bool lootable = false; // false for destroy true for loot  
   private bool playerInRange = false;
   private void OnCollisionEnter2D(Collision2D other)
   {
      if( !lootable ){
         if (other.gameObject.CompareTag("Bullet"))
         {
            DropLoot();
            Destroy(gameObject);
         }
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      Debug.Log("Entered trigger");
      if (other.gameObject.CompareTag("Player"))
      {
         playerInRange = true;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      Debug.Log("Exited trigger");
      if (other.gameObject.CompareTag("Player"))
      {
         playerInRange = false;
      }
   }

   private void DropLoot()
   {
      float shouldDrop = Random.Range(0f, 100f);
      float offsetX = Random.Range(-0.35f, 0.35f);
      float offsetY = Random.Range(-0.35f, 0.35f);
      if (shouldDrop < dropRate)
      {
         float whatToDrop = Random.Range(0f, 100f);
         if (whatToDrop < healSpawnRate)
         {
            Instantiate(healPrefab, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z), Quaternion.identity);
         }
         else if (whatToDrop < shotgunSpawnRate)
         {
            Instantiate(weaponPrefab, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z), Quaternion.identity);
         }
            
      }
   }

   private void Update()
   {
      if (playerInRange && lootable && Input.GetKeyDown(openKey))
      {
         DropLoot();
         Destroy(gameObject);
      }
   }
}
