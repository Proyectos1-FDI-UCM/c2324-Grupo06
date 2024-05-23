using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cambia la capa de un objeto a una capa determinada.
public class ChangeLayerBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] GameObject item; 
    [SerializeField] int targetLayer;
    public void ExecuteBehaviour()
    {
        item.layer = targetLayer; //Cambia la capa del objeto espec�fico a la targetlayer
    }
}
