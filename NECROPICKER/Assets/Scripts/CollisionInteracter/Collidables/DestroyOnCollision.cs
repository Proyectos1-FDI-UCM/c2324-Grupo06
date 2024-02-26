using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] float minSpeed = 2;
    Rigidbody2D rb;
    [SerializeField] LayerMask targetLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnCollide(Collider2D other)
    {
        if (rb.velocity.magnitude > minSpeed && targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            Destroy(gameObject);
            Debug.Log("AAa");
        }
        Debug.Log($"{rb.velocity.magnitude > minSpeed} velocity");
        Debug.Log($"{targetLayer == (targetLayer | (1 << other.gameObject.layer))} layer");
    }
}
