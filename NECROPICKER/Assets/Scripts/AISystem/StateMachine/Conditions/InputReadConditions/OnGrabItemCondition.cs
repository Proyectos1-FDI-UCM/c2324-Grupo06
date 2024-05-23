using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve verdadero si un GrabHandler ha agarrado un objeto.
public class OnGrabItemCondition : MonoBehaviour, ICondition
{
    [SerializeField] GrabHandler grabHandlerToCheck;
    bool grabbedItem;

    private void Awake() 
    {
        if(grabHandlerToCheck == null)
        {
            grabHandlerToCheck = FindObjectOfType<GrabHandler>();
        }

        grabHandlerToCheck.OnItemTaken.AddListener(() =>{ grabbedItem = true; print("grabbed");});
    }

    public bool CheckCondition()
    {
        if(grabbedItem)
        {
            grabbedItem = false;
            return true;
        }
        
        return grabbedItem;
    }

    private void OnValidate() {
        name = $"if some grabHandler has grabbed";
    }
}