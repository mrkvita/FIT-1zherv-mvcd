using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
   [SerializeField] private GameObject lootPrefab;
   
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Bullet"))
      {
         float dropLoot = Random.Range(0f, 100f);
         if (dropLoot <= 50)
         {
            GameObject loot = Instantiate(lootPrefab, transform.position, Quaternion.identity);
         }
         Destroy(gameObject);
      }
   }
   
}
