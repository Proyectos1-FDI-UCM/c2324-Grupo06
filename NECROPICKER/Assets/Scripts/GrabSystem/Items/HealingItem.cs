using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    [SerializeField] float healAmount = 10; // Cantidad de vida que se cura al usar el item

    // Al usar el item, se cura vida al objeto que lo contiene a través de su HealthHandler
    public bool Use(ItemHandler handler)
    {
        GetComponentInParent<HealthHandler>().Heal(healAmount);
        return true;
    }
}
