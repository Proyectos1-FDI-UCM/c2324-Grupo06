using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    //Al entrar en un trigger, se llama al metodo OnCollide de todos los collidables que tenga el objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        ICollidable[] collidables = GetComponents<ICollidable>();

        foreach (ICollidable collidable in collidables)
        {
            collidable.OnCollide(other);
        }
    }
}
