using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float minSpeed = 2;
    Rigidbody2D rb;
    [SerializeField] LayerMask targetLayer;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent(out HealthHandler healthHandler) 
        && rb.velocity.magnitude > minSpeed && targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            healthHandler.TakeDamage(damage);
            print("collided " + name);
            print("collided with " + other.gameObject.name);
        }
    }

    public void SetMinSpeed(float newMinSpeed) => minSpeed = newMinSpeed;
}
