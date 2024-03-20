using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCondition : MonoBehaviour, ICondition
{
    [SerializeField] HealthHandler healthHandler;
    [SerializeField] float damageThreshold;

    public bool CheckCondition()
    {
        return healthHandler.currentHealth <= damageThreshold;
    }
}
