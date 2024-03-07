using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
      _controller.SetSpeed(_SlowedSpeed); //Llamada al método new speed para igualar la velocidad a SlowedSpeed     
    }
    private void OnValidate() => name = $"slower";
}
