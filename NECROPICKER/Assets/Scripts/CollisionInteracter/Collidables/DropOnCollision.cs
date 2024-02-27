using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DropComponent))]
public class DropOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] float minSpeed = 2;
    Rigidbody2D rb;
    DropComponent drop;
    [SerializeField] LayerMask targetLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        drop = GetComponent<DropComponent>();
    }
    public void OnCollide(Collider2D other)
    {
        if (rb.velocity.magnitude >= minSpeed && targetLayer == (targetLayer | (1 << other.gameObject.layer))) drop.DropItems(); 
    }
}
