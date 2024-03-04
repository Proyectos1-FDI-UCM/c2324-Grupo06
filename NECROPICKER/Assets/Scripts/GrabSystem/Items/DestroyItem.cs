using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData;
    public ItemData ItemData => itemData;

    public bool Use(ItemHandler handler)
    {
        Destroy(GetComponentInParent<ParentItem>().gameObject);
        return true;
    }
}