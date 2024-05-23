using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve verdadero si el objeto está activo.
public class CheckIsActive : MonoBehaviour, ICondition
{
    [SerializeField] GameObject gameObjectToCheck;
    public bool CheckCondition() => gameObjectToCheck.activeInHierarchy;

    private void OnValidate()
    {
        name = "Check if " + gameObjectToCheck.name + " is active";
    }
}