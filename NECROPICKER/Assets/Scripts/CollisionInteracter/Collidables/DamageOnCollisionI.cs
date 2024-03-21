using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionI : MonoBehaviour, ICollidable
{
    [SerializeField] int damage = 1;
    [SerializeField] float minSpeed = 2;
    [SerializeField] LayerMask targetLayer;
    public void OnCollide(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HealthHandler healthHandler) && 
        targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            healthHandler.TakeDamage(damage);
        }
    }

    public void SetMinSpeed(float newMinSpeed) => minSpeed = newMinSpeed;
}
