using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeUI : MonoBehaviour
{
    
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
                //Debug.Log(margenesCount);
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
