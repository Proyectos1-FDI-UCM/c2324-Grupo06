using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        print(Vector2.Dot(rbToCheck.velocity, directionToCheck));
        return Vector2.Dot(rbToCheck.velocity, directionToCheck) > dotProductThreshold;
    }
        

    private void OnValidate() 
    {
        if(rbToCheck == null) rbToCheck = FindObjectOfType<InputManager>().GetComponent<Rigidbody2D>();
        
        name = $"{rbToCheck.name} move towards {directionToCheck.normalized}";
    }
}
