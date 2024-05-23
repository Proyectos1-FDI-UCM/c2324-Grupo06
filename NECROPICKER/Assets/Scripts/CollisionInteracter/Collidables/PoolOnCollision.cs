using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] GameObject[] prefabs; // Prefabs que aparecerán al colisionar
    PoolTaker poolTaker; // Componente que se encarga de gestionar los objetos de la pool

    private void Awake()
    {
        if(poolTaker == null) poolTaker = GetComponent<PoolTaker>();
        else poolTaker = gameObject.AddComponent<PoolTaker>();
    }

    public void OnCollide(Collider2D collision)
    {
        // Se activan los prefabs de la pool
        foreach (GameObject prefab in prefabs)
        {
            poolTaker.TakeFromPool(prefab);
        }
    }
}
