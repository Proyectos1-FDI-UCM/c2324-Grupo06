using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] PoolObject[] poolObjects;
    public Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
        //Para cada poolObject, crea una cola en la cual irá tantos prefabs como la cntidad que se indique en el apartado de size del poolObject, lo desactiva y los agrega a la cola. Añade la cola al diccionario
    private void Start() {
        foreach (PoolObject poolObject in poolObjects)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < poolObject.size; i++)
            {
                GameObject obj = Instantiate(poolObject.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(poolObject.prefab, objectPool);
        }
    }
    //Toma una posición, rotación y prefab, comprueba si el diccionario contiene dicho prefab (si no lo tiene salta un error), activa el objeto, lo coloca en la posición y rotación dada y lo añade al final de la lista para usos en el futuro

    public GameObject SpawnFromPool(Vector2 position, Quaternion rotation, GameObject prefab)
    {
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogWarning("Pool with tag " + prefab.name + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[prefab].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[prefab].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
//Define la estructura de cada tipo de objeto en el Pool
[System.Serializable]
public class PoolObject
{
    public GameObject prefab;
    public int size;
}
