using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeUI : MonoBehaviour
{
    /// <summary>
    /// Se encarga de gestionar la vida del player en la UI desde los corazones actuales hasta los margenes en caso de que
    /// deban ser aumentados al conseguir una mejora por ejemplo
    /// </summary>
    
    [SerializeField] private HealthHandler healthHandler;
    [SerializeField] private GameObject[] margenes = new GameObject[5];
    private int margenesCount;
    private void Start()
    {
        HealthHandler healthHandler = FindAnyObjectByType<InputManager>(FindObjectsInactive.Include).GetComponent<HealthHandler>();
        UIlife(healthHandler.currentHealth);
        healthHandler.OnHealthChanged.AddListener(UIlife);
        UIContainers(healthHandler._maxHealth);
        healthHandler.OnMaxHealthChanged.AddListener(UIContainers);
        
    }
    public void UIContainers(float maxhealth)
    {
        margenesCount = 0;
        for (int i = 0; i <= maxhealth; i++)
        {
            if (i % 4 == 0 && i != 0)
            {
                margenes[margenesCount].SetActive(true);
                margenesCount++;
            }
        }
    }
    public void UIlife(float actuallife)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i < actuallife) transform.GetChild(i).gameObject.SetActive(true);
            else transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}