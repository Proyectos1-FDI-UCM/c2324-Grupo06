using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] float minSpeed = 2;
    Rigidbody2D rb;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnCollide(Collider2D other)
    {
        if (rb.velocity.magnitude > minSpeed && targetLayer == (targetLayer | (1 << other.gameObject.layer))) Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
