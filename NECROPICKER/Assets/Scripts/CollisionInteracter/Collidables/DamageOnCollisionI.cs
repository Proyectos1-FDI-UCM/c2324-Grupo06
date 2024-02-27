using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionI : MonoBehaviour, ICollidable
{
    [SerializeField] int damage = 1;
    [SerializeField] float minSpeed = 2;
    Rigidbody2D rb;
    [SerializeField] LayerMask targetLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollide(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HealthHandler healthHandler)
        && rb.velocity.magnitude >= minSpeed && targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            healthHandler.TakeDamage(damage);
        }
    }

    public void SetMinSpeed(float newMinSpeed) => minSpeed = newMinSpeed;
}
