using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecronomiconItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    public bool Use(ItemHandler handler)
    {
        Debug.Log("NecronomiconItem used");
        return true;
    }

    public void Drop(ItemHandler handler)
    {
        Debug.Log("NecronomiconItem dropped");
    }
}
