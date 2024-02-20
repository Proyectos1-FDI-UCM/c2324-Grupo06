using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHItem : MonoBehaviour, IItem
{
    // Start is called before the first frame update
    [SerializeField]
    float damage = 1f;
    public ItemData ItemData { get; }
    public bool Use(ItemHandler handler)
    {
        HealthHandler health = GetComponentInParent<HealthHandler>();
        print(health);
        if (health != null) health.TakeDamage(damage);
        return true;
    }
}
