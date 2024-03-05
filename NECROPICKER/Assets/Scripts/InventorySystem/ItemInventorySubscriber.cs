using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventorySubscriber : MonoBehaviour
{
    ItemHandler _itemHandler;
    [SerializeField] Inventory _inventory;

    private void Start() {
        _itemHandler = GetComponent<ItemHandler>();
        _inventory.OnItemChanged.AddListener(_itemHandler.OnItemChanged);
        _itemHandler.OnItemDrop.AddListener(_inventory.RemoveItem);

        _inventory.UpdateInventory();
    }

    private void OnDestroy() {
        _inventory.OnItemChanged.RemoveListener(_itemHandler.OnItemChanged);
        _itemHandler.OnItemDrop.RemoveListener(_inventory.RemoveItem);
    }
}
