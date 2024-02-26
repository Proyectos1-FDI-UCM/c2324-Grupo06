using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundOnCollision : MonoBehaviour
{
    [SerializeField] private float _SpeedMultiplicater = 1f;
    private MovementController _movementController;
    private void Start()
    {
        _movementController = GetComponent<MovementController>();
    }

    /*  private void OnCollisionEnter2D(Collision2D collision)
      {
         MovementController otherMoveMentController = collision.gameObject.GetComponent<MovementController>();

          if (otherMoveMentController != null)
          {
              Vector3 reboundSpeed = otherMoveMentController.speed * Vector3.forward;

              Vector3 normal = collision.contacts[0].normal;

              Vector3 newDirection = reboundSpeed + Vector3.Dot(reboundSpeed, normal) * normal;

              otherMoveMentController.Move(newDirection.normalized * _SpeedMultiplicater);

          }
      }
  */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D otherrigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        if ( otherrigidbody2D != null)
        {
            Vector2 newVector2 = otherrigidbody2D.position;

            Vector2 normal = collision.contacts[0].normal;

            Vector2 newDirection = newVector2 * _SpeedMultiplicater + Vector2.Dot(newVector2,normal) * normal;

            _movementController.Move(newDirection.normalized);
        }

    }
}
