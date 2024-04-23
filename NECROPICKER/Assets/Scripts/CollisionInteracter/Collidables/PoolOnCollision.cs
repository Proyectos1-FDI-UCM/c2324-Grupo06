using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] GameObject[] prefabs;
    PoolTaker poolTaker;

    private void Awake()
    {
        if(poolTaker == null) poolTaker = GetComponent<PoolTaker>();
        else poolTaker = gameObject.AddComponent<PoolTaker>();
    }

    public void OnCollide(Collider2D collision)
    {
        foreach (GameObject prefab in prefabs)
        {
            poolTaker.TakeFromPool(prefab);
        }
    }
}
