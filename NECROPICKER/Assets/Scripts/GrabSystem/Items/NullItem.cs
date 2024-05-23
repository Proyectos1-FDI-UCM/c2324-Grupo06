using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullItem : MonoBehaviour, IItem
{
    public ItemData ItemData { get; }
    // No tiene datos, es un item nulo (Null object pattern)
    public bool Use(ItemHandler handler)
    {
        return false;
    }
}
