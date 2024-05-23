using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Realentiza la velocidad de un controlador de movimiento.
public class SlowedBehaviour : MonoBehaviour, IBehaviour
{
    MovementController _controller;
    [SerializeField] private float _SlowedSpeed = 1.0f;
    TargetHandler _targetHandler;
    private void Awake()
    {
        _targetHandler = GetComponentInParent<TargetHandler>();
        _controller = _targetHandler.transform.GetComponent<MovementController>();
    }
    public void ExecuteBehaviour()
    {    
      _controller.SetSpeed(_SlowedSpeed); //Llamada al m�todo new speed para igualar la velocidad a SlowedSpeed     
    }
    private void OnValidate() => name = $"slower";
}
