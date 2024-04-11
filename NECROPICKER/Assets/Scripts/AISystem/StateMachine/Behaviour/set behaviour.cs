using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class setbehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private bool activation = true;
    [SerializeField] GameObject gameobject;
    public void ExecuteBehaviour()
    {
        gameobject.SetActive(activation);
    }
    private void OnValidate() => name = $"set active "+ activation;
}
