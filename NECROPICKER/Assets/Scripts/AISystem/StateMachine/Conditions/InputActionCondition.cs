using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionCondition : MonoBehaviour, ICondition
{
    [SerializeField] InputAction inputaction;

    public bool CheckCondition()
    {
        print(inputaction.WasPerformedThisFrame());
         return inputaction.WasPerformedThisFrame();
    }

    private void OnValidate()
    {
        if (inputaction != null)
        {
            name = "Listen Input: " + inputaction.name;
        }
    }
}
