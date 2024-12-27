using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimitDamage : MonoBehaviour
{
    [SerializeField] private float duration;
    private DamageIntakeController damageIntakeController;

    private void Awake()
    {
        damageIntakeController = GetComponent<DamageIntakeController>();    
    }

    public void StartDontTake()
    {
        damageIntakeController.StartDontTake(duration);
    } 
  
}
