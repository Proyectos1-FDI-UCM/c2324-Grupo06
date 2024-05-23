using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve la velocidad original al controlador de movimiento que se ecuentra en el mismo GameObject.
//Esto debería ser un IBehaviour.
public class ReturnSpeedCondition : MonoBehaviour, ICondition
{
    MovementController _controller;
    private void Awake()
    {
        _controller = GetComponent<MovementController>();
    }
    public bool CheckCondition()
    {    
      _controller.ReturnOriginalSpeed(); //Llamada al m�todo new speed para igualar la velocidad a SlowedSpeed
      return true;
    }
}
