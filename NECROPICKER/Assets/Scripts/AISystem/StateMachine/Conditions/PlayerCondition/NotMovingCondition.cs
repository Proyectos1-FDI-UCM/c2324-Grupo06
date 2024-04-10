using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotMovingCondition : MonoBehaviour, ICondition
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Vector2 minVelocity;
    public bool CheckCondition()
    {
        return rb2d.velocity.x < minVelocity.x && rb2d.velocity.y < minVelocity.y;
    }
    private void OnValidate()
    {
        gameObject.name = "Not moving faster than " + minVelocity;
    }
}
