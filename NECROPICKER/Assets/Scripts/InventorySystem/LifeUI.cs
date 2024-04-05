using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeUI : MonoBehaviour
{
    
    [SerializeField] private HealthHandler healthHandler;
    [SerializeField] private GameObject[] margenes = new GameObject[5];
    private void Start()
    {
        HealthHandler healthHandler = FindAnyObjectByType<InputManager>(FindObjectsInactive.Include).GetComponent<HealthHandler>();
        UIlife(healthHandler.currentHealth);
        healthHandler.OnHealthChanged.AddListener(UIlife);
    }
    public void UIlife(float actuallife)
    {
        for (int i = 0; i < healthHandler.GetMaxHealth(); i++)
        {
            margenes[i].SetActive(true);
        }
        for (int i = 0; i < transform.childCount; i++) 
        {
            if (i < actuallife) transform.GetChild(i).gameObject.SetActive (true);
            else transform.GetChild(i).gameObject.SetActive (false);
        }
    }
}
