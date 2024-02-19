using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeUI : MonoBehaviour
{
    
    [SerializeField] private HealthHandler healthHandler;
    private void Awake()
    {
        //HealthHandler healthHandler = FindAnyObjectByType<HealthHandler>(); 
        UIlife(healthHandler.currentHealth);
        healthHandler.OnHealthChanged.AddListener(UIlife);
    }
    public void UIlife(float actuallife)
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            if (i < actuallife) transform.GetChild(i).gameObject.SetActive (true);
            else transform.GetChild(i).gameObject.SetActive (false);
        }
    }
}
