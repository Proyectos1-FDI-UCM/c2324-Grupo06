using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour, ICollidable
{
    Rigidbody2D rb;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] LayerMask requiredLayer = 9;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnCollide(Collider2D other)
    {
        if (requiredLayer == (requiredLayer | (1 << gameObject.layer)) && targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }
}
