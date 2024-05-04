using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTargetItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData;
    public ItemData ItemData => itemData;
    private Transform target;
    [SerializeField]
    LayerMask targetLayer;
    TargetHandler targetHandler;

    [SerializeField] float radius = 100f;

    private void Awake()
    {
        targetHandler = GetComponent<TargetHandler>();
    }

    public bool Use(ItemHandler handler)
    {
        try
        {
            target = Physics2D.OverlapCircle(transform.position, radius, targetLayer).transform;
        }
        catch
        {
            target = Physics2D.Raycast(transform.position, transform.up, 200f).transform;
        }
        
        targetHandler.SetTarget(target);

        return true;
    }
}
