using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultItemOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] ItemData _defaultItem; // Item que se asignará al itemHandler del objeto con el que colisiona

    public void OnCollide(Collider2D collision)
    {
        // Si el objeto con el que colisiona tiene un ItemHandler, se le asigna el item seleccionado
        ItemHandler itemHandler = collision.GetComponentInChildren<ItemHandler>();
        if(itemHandler != null) itemHandler.defaultItem = _defaultItem;
    }
}