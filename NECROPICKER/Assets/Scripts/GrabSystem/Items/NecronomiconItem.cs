using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecronomiconItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    // Al usar el item, se imprime un mensaje en la consola. Es para el desarrollo, no tiene una funcionalidad real
    public bool Use(ItemHandler handler)
    {
        Debug.Log("NecronomiconItem used");
        return true;
    }
}
