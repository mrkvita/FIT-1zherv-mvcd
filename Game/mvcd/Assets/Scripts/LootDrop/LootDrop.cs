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

   private bool isDestoryed = false;
   
   private LootDropSpawner spawner;
   
   void Start()
   {
      spawner = FindObjectOfType<LootDropSpawner>();
   }
   private void OnCollisionEnter2D(Collision2D other)
   {
      if( !lootable && other.gameObject.CompareTag("Bullet") && !isDestoryed){
            isDestoryed = true;
            Destroy(gameObject);
            DropLoot();
            spawner.counter--;
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         playerInRange = true;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         playerInRange = false;
      }
   }
   


   // this exsis in case multiple bullets hit the collider, without it the counter would underflow 
   // and unlimited amount of dropboxes would spawn
   private void DropLoot()
   { 
     float offsetX = Random.Range(-0.35f, 0.35f);
     float offsetY = Random.Range(-0.35f, 0.35f);
     float shouldDrop = Random.Range(0f, 100f);
     if (shouldDrop < dropRate)
     {
        float whatDrop = Random.Range(0f, 100f);
        if (whatDrop < healSpawnRate)
        {
         Instantiate(healPrefab, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z), Quaternion.identity);
        }
        else if (whatDrop < shotgunSpawnRate)
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
