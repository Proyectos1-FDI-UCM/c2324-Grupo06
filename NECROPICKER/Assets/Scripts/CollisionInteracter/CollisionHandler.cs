using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] UnityEvent onCollision = new UnityEvent(); // Evento que se dispara al colisionar
    [SerializeField] LayerMask requiredLayer; // Capa requerida para que se dispare el evento
    [SerializeField] LayerMask targetLayer; // Capa con la que se debe colisionar para que se dispare el evento
    ICollidable[] collidables;

    private void Awake()
    {
        collidables = GetComponents<ICollidable>();
    }
    // Al colisionar con un objeto, se hace un chequeo de las capas
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la capa de la colisión es la requerida y la capa del objeto es la requerida, se dispara el evento
        if (targetLayer == (targetLayer | (1 << collision.gameObject.layer)) && requiredLayer == (requiredLayer | 1 << gameObject.layer))
        {
            onCollision?.Invoke();

            // Y se llama al método OnCollide de todos los collidables que tenga el objeto
            foreach (ICollidable collidable in collidables)
            {
                collidable.OnCollide(collision.collider);
            }
        }
    }
}
