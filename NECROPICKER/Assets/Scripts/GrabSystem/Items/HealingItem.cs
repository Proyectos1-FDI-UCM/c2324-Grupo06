using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    [SerializeField] float healAmount = 10;

    public bool Use(ItemHandler handler)
    {
        GetComponentInParent<HealthHandler>().Heal(healAmount);
        handler.DropItem();
        print("Healing");
        Destroy(gameObject);
        return true;
    }
}
