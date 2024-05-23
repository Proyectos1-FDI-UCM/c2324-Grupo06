using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve verdadero si la vida del objeto es menor o igual a un umbral determinado.
public class DamageCondition : MonoBehaviour, ICondition
{
    [SerializeField] HealthHandler healthHandler;
    [SerializeField] float damageThreshold;

    public bool CheckCondition()
    {
        return healthHandler.currentHealth <= damageThreshold;
    }
}
