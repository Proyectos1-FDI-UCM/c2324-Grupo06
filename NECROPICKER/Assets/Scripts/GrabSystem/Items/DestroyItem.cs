using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData;
    public ItemData ItemData => itemData;

    // Al usar el item, se destruye el objeto que lo contiene, y por lo tanto el item
    public bool Use(ItemHandler handler)
    { 
        Destroy(GetComponentInParent<ParentItem>().gameObject);
        return true;
    }
}