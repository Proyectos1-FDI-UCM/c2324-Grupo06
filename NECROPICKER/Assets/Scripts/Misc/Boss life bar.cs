using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosslifebar : MonoBehaviour
{
    [SerializeField] private HealthHandler healthHandler;
    [SerializeField] private Slider slider;
    
    private void Start()
    {
        slider.maxValue = healthHandler.GetMaxHealth();
        slider.value = healthHandler.GetMaxHealth();
    }
    public void Bossbar()
    {
        slider.value = healthHandler.GetCurrentHealth() - 1;
    }
}
