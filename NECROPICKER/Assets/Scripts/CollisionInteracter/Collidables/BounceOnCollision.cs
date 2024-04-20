using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    [SerializeField] float minSpeed = 2;
    [SerializeField] float bounceFactor = 1;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(rb.velocity.magnitude > minSpeed)
        {
            rb.velocity = Vector2.Reflect(rb.velocity, other.GetContact(0).normal) * bounceFactor;
        }
    }
}
