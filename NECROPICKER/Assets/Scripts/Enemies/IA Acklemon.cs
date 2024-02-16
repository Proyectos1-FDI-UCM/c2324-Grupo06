using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAAcklemon : MonoBehaviour
{
    #region parameters
    [SerializeField] private float _SlowedSpeed = 1.0f; //Nueva variable de Velocidad para el jugador si entra en rango del enemigo
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MovementController _movementController)) 
        { 
            _movementController.SetSpeed(_SlowedSpeed); //Llamada al método new speed para igualar la velocidad a SlowedSpeed
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MovementController _movementController))
        {
            _movementController.ReturnOriginalSpeed(); //Llamada al método Return speed para devolver la velocidad original
        }
    }

    #endregion
}
