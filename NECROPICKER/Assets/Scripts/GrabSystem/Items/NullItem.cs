using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullItem : MonoBehaviour, IItem
{
    public ItemData ItemData { get; }
    public bool Use(ItemHandler handler)
    {
        return false;
    }
}
