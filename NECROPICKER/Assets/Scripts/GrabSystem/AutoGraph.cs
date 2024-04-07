using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class AutoGraph : MonoBehaviour
{
    [SerializeField] Inventory _inventory;
    [SerializeField] ItemData _item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out InputManager inputManager))
        {
            if(_inventory.items[0].amount < _item.maxStackSize)
            {
                if (_inventory.AddItem(_item))
                {
                    _inventory.UpdateInventory();
                    Destroy(gameObject);
                }
            }
        }
    }
}
