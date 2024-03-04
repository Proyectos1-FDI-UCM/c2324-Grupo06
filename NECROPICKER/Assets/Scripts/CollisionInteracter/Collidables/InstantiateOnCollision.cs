using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] private GameObject prefab;

    public void OnCollide(Collider2D other)
    {
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer))) Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
