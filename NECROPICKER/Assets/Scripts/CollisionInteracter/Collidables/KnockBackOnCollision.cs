using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] private float _speedMultiplier = 1f;
    [SerializeField] private float minSpeed;
    [SerializeField] private LayerMask targetLayer;
    Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();
    
    public void OnCollide(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Rigidbody2D rigidbody2D)
        && rb.velocity.magnitude >= minSpeed && targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            rigidbody2D.velocity = (other.transform.position - transform.position).normalized * _speedMultiplier;
        }
    }
}
