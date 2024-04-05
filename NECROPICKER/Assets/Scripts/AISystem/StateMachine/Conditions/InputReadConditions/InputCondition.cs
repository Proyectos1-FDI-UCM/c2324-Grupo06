using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCondition : MonoBehaviour, ICondition
{
    [SerializeField] InputActionReference inputactionreference;
    public bool CheckCondition() => inputactionreference.action.WasPerformedThisFrame();
}
