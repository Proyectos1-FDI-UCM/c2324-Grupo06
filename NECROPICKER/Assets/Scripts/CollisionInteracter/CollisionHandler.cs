using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] UnityEvent onCollision = new UnityEvent();
    [SerializeField] LayerMask requiredLayer;
    [SerializeField] LayerMask targetLayer;
    ICollidable[] collidables;

    private void Awake()
    {
        collidables = GetComponents<ICollidable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(targetLayer == (targetLayer | (1 << collision.gameObject.layer)) && requiredLayer == (requiredLayer | 1 << gameObject.layer))
        {
            onCollision?.Invoke();

            foreach(ICollidable collidable in collidables)
            {
                collidable.OnCollide(collision.collider);
            }
        }
    }
}
