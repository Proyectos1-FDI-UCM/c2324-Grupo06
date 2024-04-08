using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolTaker))]
public class PoolOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] GameObject[] prefabs;
    PoolTaker poolTaker;

    private void Awake()
    {
        poolTaker = GetComponent<PoolTaker>();
    }

    public void OnCollide(Collider2D collision)
    {
        foreach (GameObject prefab in prefabs)
        {
            poolTaker.TakeFromPool(prefab);
        }
    }
}
