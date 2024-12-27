using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HealthController : MonoBehaviour
{
   [SerializeField] private float currentHealth;

   [SerializeField] private float maxHealth;

   private float PercentageLeft
   {
      get{
         return currentHealth / maxHealth;
         }
   }

   public bool dontGetHit { get; set; }
      
   public void TakeDamage(float damage)
   {
      if (dontGetHit)
      {
         return;
      }
      if (currentHealth < damage)
      {
         currentHealth = 0;
         OnDeath.Invoke();   
         return;
      }
      else{
         currentHealth -= damage;
         OnHit.Invoke();
      }
   }
   
   public UnityEvent OnDeath;

   public UnityEvent OnHit;

   public void Heal(float heal)
   {
      if (currentHealth + heal >= maxHealth)
      {
        currentHealth = maxHealth; 
      }
      else
      {
         currentHealth += heal;
      }
   }
   
}
