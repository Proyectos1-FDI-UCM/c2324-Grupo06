using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosslifebar : MonoBehaviour
{
    [SerializeField] private HealthHandler healthHandler;
    [SerializeField] Image bar;
    
    private void Awake()
    {   
      
        HealthHandler healthHandler = GetComponentInParent<HealthHandler>();

    }
    private void Start()
    {
        bar.fillAmount = 1;
    }
    public void Bossbar()
    {
        bar.fillAmount = healthHandler.GetCurrentHealth()/healthHandler.GetMaxHealth();
    }
}
