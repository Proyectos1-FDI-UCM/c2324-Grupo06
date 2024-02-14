using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAAcklemon : MonoBehaviour
{
    #region parameters
    [SerializeField] private float _SlowedSpeed = 1.0f; //Nueva variable de Velocidad para el jugador si entra en rango del enemigo
    #endregion
    #region referneces
    private MovementController _movementController; //Referencia al componente de movimiento
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InputManager>() != null)
        {
            _movementController.SetSpeed(_SlowedSpeed); //Llamada al método new speed para igualar la velocidad a SlowedSpeed
        }
    }
    
    #endregion
    private void Start()
    {
        _movementController = GetComponent<MovementController>();
    }
}
