using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTaker : MonoBehaviour
{
    ObjectPooler objectPooler;
    [SerializeField] Transform spawnPoint;

    private void Awake() {
        objectPooler = FindObjectOfType<ObjectPooler>(true);

        if(objectPooler == null)
        {
            Debug.LogWarning("ObjectPooler not found");
            Destroy(this);
        }

        if(spawnPoint == null)
        {
            spawnPoint = transform;
        }
    }

    public void TakeFromPool(GameObject prefab)
    {
        objectPooler.SpawnFromPool(spawnPoint.position, spawnPoint.rotation, prefab);
    }
}
