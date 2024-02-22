using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DropComponent))]
public class DropOnCollision : MonoBehaviour
{
    [SerializeField] float minSpeed = 2;
    Rigidbody rb;
    DropComponent drop;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        drop = GetComponent<DropComponent>();
    }
    public void OnCollide(Collider2D other)
    {
        if (rb.velocity.magnitude > minSpeed && targetLayer == (targetLayer | (1 << other.gameObject.layer))) drop.DropItems();
    }
}
