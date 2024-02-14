using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour, IBehaviour
{
    TargetHandler targetHandler;
    MovementController movementController;
    [SerializeField]float multiplier = 1;

    private void Awake()
    { 
        targetHandler = GetComponentInParent<TargetHandler>();
        movementController = GetComponentInParent<MovementController>();
    }

    public void ExecuteBehaviour() => movementController.MoveTowards(targetHandler.target.position, multiplier);

    private void OnValidate() {
        movementController = GetComponentInParent<MovementController>();
        if(movementController == null) return;

        if(multiplier >= 1)
            gameObject.name = $"Follow Target {multiplier * movementController.speed} m/s";
        else
            gameObject.name = $"Move Away {multiplier * movementController.speed} m/s";
    }
}
