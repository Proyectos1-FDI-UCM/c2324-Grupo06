using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBehaviour : MonoBehaviour, IBehaviour
{
    MovementController movementController;

    private void Awake() => movementController = GetComponentInParent<MovementController>();

    public void ExecuteBehaviour() => movementController.Move(Vector2.zero);
}
