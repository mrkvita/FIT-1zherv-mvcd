using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HealthController : MonoBehaviour
{
   [SerializeField] private float currentHealth;

   [SerializeField] private float maxHealth;
   
   public float Health => currentHealth;
   
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
         OnHealthChanged.Invoke();
      }
   }
   
   public UnityEvent OnDeath;

   public UnityEvent OnHit;

   public UnityEvent OnHealthChanged;
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
