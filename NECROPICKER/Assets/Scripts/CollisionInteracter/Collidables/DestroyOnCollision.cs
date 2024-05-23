using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour, ICollidable
{
    // Al colisionar con otro objeto, se destruye a sí mismo
    public void OnCollide(Collider2D other)
    {
        
        Destroy(gameObject);
    }
}
