using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
   [SerializeField] private GameObject lootPrefab1;
   [SerializeField] private GameObject lootPrefab2;
   
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Bullet"))
      {
         float dropLoot = Random.Range(0f, 100f);
         if (dropLoot <= 30)
         {
            GameObject loot = Instantiate(lootPrefab1, transform.position, Quaternion.identity);
         }
         else if (dropLoot <= 60)
         {
            GameObject loot = Instantiate(lootPrefab2, transform.position, Quaternion.identity);
         }
         Destroy(gameObject);
      }
   }
   
}
