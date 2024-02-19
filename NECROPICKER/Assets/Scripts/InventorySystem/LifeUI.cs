using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    
    public HealthHandler healthHandler;
    private void Awake()
    {
        HealthHandler healthHandler = FindAnyObjectByType<HealthHandler>(); 
        UIlife(healthHandler.currentHealth);
    }
    private void Update()
    {
        UIlife(healthHandler.currentHealth);
    }
    public void UIlife(float actuallife)
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            if (i< actuallife) transform.GetChild(i).gameObject.SetActive (true);
            else transform.GetChild(i).gameObject.SetActive (false);
        }
    }
}
