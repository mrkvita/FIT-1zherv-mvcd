using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDontTakeDamage: MonoBehaviour
{
    [SerializeField] private float duration;
    private DamageIntakeController damageIntakeController;

    private void Awake()
    {
        damageIntakeController = GetComponent<DamageIntakeController>();
        if (damageIntakeController == null)
        {
            Debug.LogError("PlayerDontTakeDamage: No DamageIntakeController component attached");
            return;
        }
    }

    public void StartDontTake()
    {
        damageIntakeController.StartDontTake(duration);
    } 
  
}
