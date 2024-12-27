using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIntakeController : MonoBehaviour
{
   private HealthController healthController;
  private void Awake()
   {
      healthController = GetComponent<HealthController>();
      if (healthController == null)
      {
         Debug.LogError("Health Controller not found");
         return;
      }
   }

   public void StartDontTake(float duration)
   {
      StartCoroutine(DontTakeCoroutine(duration));
   }

   private IEnumerator DontTakeCoroutine(float duration)
   {
      if(healthController != null) {
         healthController.dontGetHit = true;
         yield return new WaitForSeconds(duration);
         healthController.dontGetHit = false;
      }
   }
}
