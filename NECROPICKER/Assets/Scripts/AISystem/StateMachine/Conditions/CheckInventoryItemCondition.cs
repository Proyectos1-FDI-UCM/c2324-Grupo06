using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInventoryItemCondition : MonoBehaviour, ICondition
{
    [SerializeField] ItemData itemToCheck;
    [SerializeField] Inventory inventory;

    public bool CheckCondition() => inventory.HasItem(itemToCheck);

    private void OnValidate()
    {
        name = "Check if " + itemToCheck.itemName + " is in inventory";
    }
}
