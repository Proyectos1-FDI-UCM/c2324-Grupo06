using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBehaviour : MonoBehaviour, IBehaviour
{
    MovementController movementController;
    [Range(0, 1)]
    [SerializeField] float stopVelocity = 1f;

    private void Awake() => movementController = GetComponentInParent<MovementController>();

    public void ExecuteBehaviour()
    {
        movementController.Rb.velocity = Vector2.Lerp(movementController.Rb.velocity, Vector2.zero, 
        stopVelocity * 35 * Time.deltaTime * movementController.Rb.velocity.magnitude);
    }

    private void OnValidate() {
        name = "Stop -> " + stopVelocity * 100 + "%";
    }
}
