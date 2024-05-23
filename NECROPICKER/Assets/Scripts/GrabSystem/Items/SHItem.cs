using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SHItem : MonoBehaviour, IItem
{
    [SerializeField]
    float damage = 1f; // Cantidad de da�o que se hace al usar el item
    public ItemData ItemData { get; }
    // Al usar el item, se hace da�o al objeto que lo contiene a trav�s de su HealthHandler. Se usa para el necronomicon
    public bool Use(ItemHandler handler)
    {
        HealthHandler health = GetComponentInParent<HealthHandler>();
        if (health != null) health.NecroDamage(damage);
        return true;
    }
}
