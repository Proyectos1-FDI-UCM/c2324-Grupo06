using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DropComponent))]
public class DropOnCollision : MonoBehaviour, ICollidable
{
    DropComponent drop;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] bool exclusiveDrop = false;
    int numOfInstances = 0;
    [SerializeField] int maxNumOfInstances = 1;

    private void Awake()
    {
        drop = GetComponent<DropComponent>();
    }

    public void OnCollide(Collider2D other)
    {
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer)) && numOfInstances < maxNumOfInstances)
        {
            if (exclusiveDrop) drop.DropItemExclusive();
            else drop.DropItem();
        }
    }
}
