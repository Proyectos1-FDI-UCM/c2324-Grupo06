using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeaponBehaviour : MonoBehaviour, IBehaviour
{
    ItemHandler itemHandler;

    private void Awake()
    {
        itemHandler = GetComponentInParent<ItemHandler>();
    }

    public void ExecuteBehaviour()
    {
        itemHandler.UseItem();
    }

    private void OnValidate() {
        itemHandler = GetComponentInParent<ItemHandler>();
        if(itemHandler == null) return;

        if(itemHandler.initialItem != null)
            name = $"Use {itemHandler.initialItem.itemName}";
    }
}
