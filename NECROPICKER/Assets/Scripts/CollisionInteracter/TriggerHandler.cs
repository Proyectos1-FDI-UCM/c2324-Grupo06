using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ICollidable[] collidables = GetComponents<ICollidable>();

        foreach (ICollidable collidable in collidables)
        {
            collidable.OnCollide(other);
        }
    }
}
