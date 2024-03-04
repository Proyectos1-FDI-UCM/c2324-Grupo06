using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IItem
{
    ItemData ItemData { get; }
    GameObject gameObject { get; }
    bool Use(ItemHandler handler);
}
