using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve verdadero si detecta un objeto en una capa determinada al menos a una distancia determinada en
//la dirección a la que apunta el GameObject.
public class RayCastCondition : MonoBehaviour, ICondition
{
    [SerializeField] float length = 10;
    [SerializeField] LayerMask targetLayer;

    public bool CheckCondition()
    {
        return Physics2D.Raycast(transform.position, transform.up, length, targetLayer);
    }
}
