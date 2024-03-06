using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSpeedCondition : MonoBehaviour, ICondition
{
    MovementController _controller;
    [SerializeField] private float _SlowedSpeed = 1.0f;
    private void Awake()
    {
        _controller = GetComponent<MovementController>();
    }
    public bool CheckCondition()
    {    
      _controller.ReturnOriginalSpeed(); //Llamada al método new speed para igualar la velocidad a SlowedSpeed
      return true;
    }
}
