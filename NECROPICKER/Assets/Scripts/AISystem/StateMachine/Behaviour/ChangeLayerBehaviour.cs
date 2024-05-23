using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChangeDistanceItem : MonoBehaviour, IBehaviour
{
    [SerializeField] GameObject item; 
    [SerializeField] int targetLayer;
    public void ExecuteBehaviour()
    {
        item.layer = targetLayer; //Cambia la capa del objeto espec�fico a la targetlayer
    }
}
