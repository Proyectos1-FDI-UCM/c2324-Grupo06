using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundOnCollision : MonoBehaviour
{
    [SerializeField] private float _SpeedMultiplicater = 1f;
    [SerializeField] private float _minSpeed;
    [SerializeField] private LayerMask _ColisionLayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
            Vector2 direction = (Vector2)collision.transform.position - collision.contacts[0].point;
            direction.Normalize();
            collision.otherRigidbody.velocity = direction * _SpeedMultiplicater;
       
    }
}
