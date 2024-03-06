using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCircleCondition : MonoBehaviour, ICondition
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float radius = 10;
    [SerializeField] Transform center;

    private void Awake() {
        if(center == null) center = transform;
    }

    public bool CheckCondition()
    {
        return Physics2D.OverlapCircle(center.position, radius, layerMask);
    }
}