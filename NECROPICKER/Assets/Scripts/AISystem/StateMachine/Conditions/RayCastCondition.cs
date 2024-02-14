using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCondition : MonoBehaviour, ICondition
{
    TargetHandler targetHandler;
    Pointer pointer;
    [SerializeField] float length = 10;

    private void Awake()
    {
        targetHandler = GetComponentInParent<TargetHandler>();
        pointer = GetComponentInParent<Pointer>();
    }

    public bool CheckCondition()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, pointer.GetDirection(), length, targetHandler.gameObject.layer);
        return hit;
    }
}
