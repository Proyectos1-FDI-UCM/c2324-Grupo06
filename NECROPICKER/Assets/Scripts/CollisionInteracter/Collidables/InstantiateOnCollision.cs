using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] LayerMask targetLayer; // Layer con la que deber�a colisionar
    [SerializeField] private GameObject prefab; // Prefab que se instanciar� al colisionar
    [SerializeField] int maxNumOfInstances = 1; // N�mero m�ximo de instancias que se pueden instanciar
    int numOfInstances = 0; // N�mero de instancias que se han instanciado

    public void OnCollide(Collider2D other)
    {
        // Si la capa del objeto es la requerida y no se ha llegado al n�mero m�ximo de instancias, se instancia el prefab
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer)) && numOfInstances < maxNumOfInstances) 
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            numOfInstances++;
        }
    }
}
