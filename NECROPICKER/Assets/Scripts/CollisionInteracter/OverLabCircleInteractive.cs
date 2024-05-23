using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLabCircleInteractive : MonoBehaviour
{
    [SerializeField] Vector2 point; //punto central del circulo
    [SerializeField] float radius; //radio del circulo

    //Por cada Collider dentro del círculo, se llama al método OnCollide de todos los collidables que tenga el objeto
    private void OnEnable()
    {
        Collider2D[] other = Physics2D.OverlapCircleAll(point,radius);
        foreach (ICollidable collidable in GetComponents<ICollidable>())
        {
            foreach(Collider2D collider in other)
            {   
                collidable.OnCollide(collider);
            }
        } 
    }
    void OnDrawGizmos()
    {
        // Muestra el círculo en el editor
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
