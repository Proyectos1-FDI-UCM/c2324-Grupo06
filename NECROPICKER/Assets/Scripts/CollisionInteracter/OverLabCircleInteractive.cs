using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLabCircleInteractive : MonoBehaviour
{
    [SerializeField] Vector2 point;
    [SerializeField] float radius;
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
        // Display the explosion radius when selected
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
