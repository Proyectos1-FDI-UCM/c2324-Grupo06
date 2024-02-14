using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMovement : MonoBehaviour, IBehaviour
{
    MovementController movementController;
    TargetHandler targetHandler;
    [SerializeField] float orbit_radius = 5f;

    private void Awake() {
        movementController = GetComponentInParent<MovementController>();
        targetHandler = GetComponentInParent<TargetHandler>();
    }

    public void ExecuteBehaviour()
    {
        //Describe an orbit around the target
        Vector2 direction = (targetHandler.target.position - transform.position).normalized;
        Vector2 perpendicular = new Vector2(-direction.y, direction.x).normalized;

        if(Vector2.Distance(targetHandler.target.position, transform.position) < orbit_radius + 0.5f)
            perpendicular += direction;
        else if(Vector2.Distance(targetHandler.target.position, transform.position) > orbit_radius - 0.5f)
            perpendicular -= direction;
        else
            perpendicular = Vector2.zero;

        movementController.Move(perpendicular);
    }

    private void OnValidate() {
        name = $"Orbit: {orbit_radius} m";
    }
}
