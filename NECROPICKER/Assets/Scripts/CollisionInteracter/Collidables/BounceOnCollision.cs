using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    [SerializeField] float minSpeed = 2; // Velocidad mínima para rebotar
    [SerializeField] float bounceFactor = 1; // Factor de rebote
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Al colisionar con un objeto, se hace un chequeo de la velocidad
    private void OnCollisionEnter2D(Collision2D other) {
        if(rb.velocity.magnitude > minSpeed)
        {
            // Si se pasa el chequeo, se lleva a cabo el rebote
            rb.velocity = Vector2.Reflect(rb.velocity, other.GetContact(0).normal) * bounceFactor;
        }
    }
}
