using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    protected MovementController movementController;
    protected Rigidbody2D rb;
    [SerializeField] float multiplier = 1f;

    public virtual void Awake()
    {
        movementController = GetComponentInParent<MovementController>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    public virtual bool Use(ItemHandler handler)
    {
        handler.DropItem();
        transform.parent.gameObject.layer = LayerMask.NameToLayer("bullet");
        movementController.Move(transform.up * multiplier);
        return true;
    }
}
