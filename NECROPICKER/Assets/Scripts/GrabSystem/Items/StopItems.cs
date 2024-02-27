using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopItems : MonoBehaviour //, IItem
{
    public ItemData ItemData { get; }
    public GameObject gameObject { get; }

    List<IItem> items = new List<IItem>();
    /*public bool Use(ItemHandler handler)
    { }*/
}
