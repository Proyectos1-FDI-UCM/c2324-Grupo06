using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve verdadero si hay un objeto en una capa determinada dentro de un radio determinado.
public class OverlapCircleCondition : MonoBehaviour, ICondition
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float radius = 10;
    [SerializeField] Transform center;

    private void Awake() {
        if(center == null) center = transform;
    }

    public bool CheckCondition()
    {
        return Physics2D.OverlapCircle(center.position, radius, layerMask);
    }

    private void OnValidate() {
        name = "Overlap Circle Condition " + radius + "m";
    }

    private void OnDrawGizmos() {
        if(center == null) center = transform;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(center.position, radius);
    }
}