using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    [SerializeField] private HealthController healthController;

    
    public void SetMax(float max)
    {
        healthSlider.maxValue = max;
        healthSlider.value = max;
    }

    public void UpdateSlider()
    {
        if (healthController != null)
        {
            healthSlider.value = healthController.Health;
        }
    }
}
