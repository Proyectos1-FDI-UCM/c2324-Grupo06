using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    ItemData ItemData { get; }
    GameObject gameObject { get; }
    bool Use(ItemHandler handler);
    void Drop(ItemHandler handler);
}
