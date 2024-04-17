using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour, ICollidable
{
    public void OnCollide(Collider2D other)
    {
        
        Destroy(gameObject);
    }
}
