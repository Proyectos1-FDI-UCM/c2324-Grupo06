using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData; // Datos del item
    public ItemData ItemData => _itemData;

    protected MovementController movementController; // Componente de movimiento
    protected Rigidbody2D rb; // Componente de Rigidbody2D
    ParentItem parent; // Componente de ParentItem
    [SerializeField] float multiplier = 1f; // Multiplicador de velocidad al lanzar el item


    public virtual void Awake()
    {
        parent = GetComponentInParent<ParentItem>();
        movementController = GetComponentInParent<MovementController>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Al usar el item, se suelta el objeto que lo contiene, se cambia de capa y se lanza en la dirección a la que esté mirando el jugador
    public virtual bool Use(ItemHandler handler)
    {
        handler.DropItem();
        parent.transform.gameObject.layer = LayerMask.NameToLayer("bullet");
        movementController.Move(transform.up * multiplier);
        return true;
    }
}
