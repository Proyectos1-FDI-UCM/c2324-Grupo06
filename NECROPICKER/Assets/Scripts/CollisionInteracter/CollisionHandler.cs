using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICollidable[] collidables = GetComponents<ICollidable>();

        foreach(ICollidable collidable in collidables)
        {
            Debug.Log(collidable);
            collidable.OnCollide(collision.collider);
        }
    }
}
