using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mueve al objeto hacia el objetivo dado por el TargetHandler.
//Se puede ajustar el multiplicador de velocidad de forma que se pueda mover más rápido o más lento
//además de hacer que el objeto se aleje del objetivo.
//Se puede ajustar el peso de la interpolación para que el objeto ajuste su velocidad de forma más suave.
public class FollowTarget : MonoBehaviour, IBehaviour
{
    TargetHandler targetHandler;
    MovementController movementController;
    [SerializeField]float multiplier = 1;
    [Range(0, 1)]
    [SerializeField] float weight = 1f;

    private void Awake()
    { 
        targetHandler = GetComponentInParent<TargetHandler>();
        movementController = GetComponentInParent<MovementController>();
    }

    public void ExecuteBehaviour()
    {
        Vector2 direction = (targetHandler.target.position - transform.position).normalized * multiplier;
        Vector2 fixedDirection = Vector2.Lerp(movementController.Rb.velocity.normalized, direction, Time.deltaTime * weight * 100);
        movementController.Move(fixedDirection);
    }

    private void OnValidate() {
        movementController = GetComponentInParent<MovementController>();
        if(movementController == null) return;

        if(multiplier >= 1)
            gameObject.name = $"Follow Target {multiplier * movementController.speed} m/s";
        else
            gameObject.name = $"Move Away {multiplier * movementController.speed} m/s";
    }
}
