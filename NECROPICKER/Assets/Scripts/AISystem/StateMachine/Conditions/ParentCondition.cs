using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve verdadero si el objeto tiene un padre determinado.
public class ParentCondition : MonoBehaviour, ICondition
{
    [SerializeField] private Transform objectToCheckParent;
    [SerializeField] private Transform requiredParent;
    public bool CheckCondition()
    {
        if(requiredParent == null) return objectToCheckParent.parent == null;
        return objectToCheckParent.parent == requiredParent;
    }
}
