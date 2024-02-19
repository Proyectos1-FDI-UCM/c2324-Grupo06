using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public GameObject[] HalfHearts = new GameObject[6];
    public HealthHandler healthHandler;
    private void Awake()
    {
        HealthHandler healthHandler = FindAnyObjectByType<HealthHandler>();
        //Transform parentTransform = transform;
        
       /* int i = 0;
        foreach (GameObject child in parentTransform)
       {
           HalfHearts[i] = child;
           i++;
       }*/
        UIlife(healthHandler.currentHealth);
    }
    private void Update()
    {
        UIlife(healthHandler.currentHealth);
    }
    public void UIlife(float actuallife)
    {
        for (int i = 0; i < HalfHearts.Length; i++) 
        {
            if (i< actuallife) HalfHearts[i].gameObject.SetActive (true);
            else HalfHearts[i].gameObject.SetActive (false);
        }
    }
}
