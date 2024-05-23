using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionI : MonoBehaviour, ICollidable
{
    [SerializeField] int damage = 1; // Daño que se le hace al objetivo al colisionar
    [SerializeField] float minSpeed = 2;
    [SerializeField] LayerMask targetLayer; // Capa con la que se debe colisionar para que se dispare el evento
    public void OnCollide(Collider2D other)
    {
        // Si el objeto con el que colisiona tiene un HealthHandler y la capa del objeto es la requerida, se le hace daño
        if (other.gameObject.TryGetComponent(out HealthHandler healthHandler) && 
        targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            healthHandler.TakeDamage(damage);
        }
    }

    public void SetMinSpeed(float newMinSpeed) => minSpeed = newMinSpeed;
}
