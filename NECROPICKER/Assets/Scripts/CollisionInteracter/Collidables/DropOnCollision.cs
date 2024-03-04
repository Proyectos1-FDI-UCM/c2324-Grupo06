using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DropComponent))]
public class DropOnCollision : MonoBehaviour, ICollidable
{
    DropComponent drop;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] bool exclusiveDrop = false;
    [SerializeField] LayerMask requiredLayer;

    private void Awake()
    {
        drop = GetComponent<DropComponent>();
    }
    public void OnCollide(Collider2D other)
    {
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer)) && requiredLayer == (requiredLayer | (1 << gameObject.layer)))
        {
            if (exclusiveDrop) drop.DropItemExclusive();
            else drop.DropItem();
        }
    }
}
