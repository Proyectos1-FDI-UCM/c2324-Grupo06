using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBehaviour : MonoBehaviour, IBehaviour
{
    MovementController movementController;

    private void Awake() => movementController = GetComponentInParent<MovementController>();

    public void ExecuteBehaviour()
    {
        movementController.Rb.velocity = Vector2.zero;
    }

    // IEnumerator Stop()
    // {
    //     while (movementController.Rb.velocity.magnitude > 0.1f)
    //     {
    //         movementController.Rb.velocity = Vector2.Lerp(movementController.Rb.velocity, Vector2.zero, 
    //         stopVelocity);
    //         yield return new WaitForSeconds(0.01f);
    //     }
    // }

    private void OnValidate() {
        name = "Stop";
    }
}
