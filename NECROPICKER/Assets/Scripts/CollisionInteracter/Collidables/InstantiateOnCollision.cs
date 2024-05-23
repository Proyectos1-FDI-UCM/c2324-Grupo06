using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] LayerMask targetLayer; // Layer con la que debería colisionar
    [SerializeField] private GameObject prefab; // Prefab que se instanciará al colisionar
    [SerializeField] int maxNumOfInstances = 1; // Número máximo de instancias que se pueden instanciar
    int numOfInstances = 0; // Número de instancias que se han instanciado

    public void OnCollide(Collider2D other)
    {
        // Si la capa del objeto es la requerida y no se ha llegado al número máximo de instancias, se instancia el prefab
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer)) && numOfInstances < maxNumOfInstances) 
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            numOfInstances++;
        }
    }
}
