using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] private float _speedMultiplier = 1f; // Velocidad del knockback
    [SerializeField] private LayerMask targetLayer; // Capa con la que se debe colisionar


    public void OnCollide(Collider2D other)
    {
        // Si el objeto con el que colisiona tiene un Rigidbody2D y la capa del objeto es la requerida, se le aplica knockback
        if (other.gameObject.TryGetComponent(out Rigidbody2D rigidbody2D) && targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            // Se le aplica una velocidad en dirección contraria a la del objeto con el que colisiona
            rigidbody2D.velocity = (other.transform.position - transform.position).normalized * _speedMultiplier;
        }
    }
}
