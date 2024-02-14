using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCondition : MonoBehaviour, ICondition
{
    TargetHandler targetHandler;
    [SerializeField] Vector2 range;

    private void Awake()
    {
        targetHandler = GetComponentInParent<TargetHandler>();
    }

    public bool CheckCondition()
    {
        float distance = Vector2.Distance(transform.position, targetHandler.target.position);
        return distance >= range.x && distance <= range.y;
    }

    private void OnValidate() => gameObject.name = $"distance({range.x}, {range.y})";
}
