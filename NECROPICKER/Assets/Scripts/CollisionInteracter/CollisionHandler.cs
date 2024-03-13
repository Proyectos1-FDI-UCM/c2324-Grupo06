using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] UnityEvent onCollision = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollision?.Invoke();
        ICollidable[] collidables = GetComponents<ICollidable>();

        foreach(ICollidable collidable in collidables)
        {
            print(collidable.GetType());
            collidable.OnCollide(collision.collider);
        }
    }
}
