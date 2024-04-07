using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(grabHandlerToCheck == null) grabHandlerToCheck = FindObjectOfType<GrabHandler>();
        name = $"if {grabHandlerToCheck.name} has grabbed";
    }
}