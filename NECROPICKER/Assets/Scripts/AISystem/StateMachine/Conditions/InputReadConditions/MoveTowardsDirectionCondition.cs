using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve verdadero si el objeto se mueve en una dirección determinada.
public class MoveTowardsDirectionCondition : MonoBehaviour, ICondition
{
    [SerializeField] Rigidbody2D rbToCheck;
    [SerializeField] Vector2 directionToCheck;
    [SerializeField] float dotProductThreshold = 0.5f;

    private void Awake()
    {
        if(rbToCheck == null)
        {
            rbToCheck = FindObjectOfType<InputManager>().GetComponent<Rigidbody2D>();
        }

        directionToCheck.Normalize();
    }

    public bool CheckCondition()
    {
        return Vector2.Dot(rbToCheck.velocity, directionToCheck) > dotProductThreshold;
    }
        

    private void OnValidate() 
    {
        name = $"Something move towards {directionToCheck.normalized}";
    }
}
