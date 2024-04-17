using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultItemOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] ItemData _defaultItem;

    public void OnCollide(Collider2D collision)
    {
        ItemHandler itemHandler = collision.GetComponentInChildren<ItemHandler>();
        if(itemHandler != null) itemHandler.defaultItem = _defaultItem;
    }
}