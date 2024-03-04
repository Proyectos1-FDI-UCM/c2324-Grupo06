using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTargetItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData;
    public ItemData ItemData => itemData;
    [SerializeField]
    LayerMask targetLayer;
    TargetHandler targetHandler;

    private void Awake()
    {
        targetHandler = GetComponent<TargetHandler>();
    }

    public bool Use(ItemHandler handler)
    {
        targetHandler.SetTarget(Physics2D.OverlapCircle(transform.position, 15f, targetLayer).transform);
        Debug.Log(Physics2D.OverlapCircle(transform.position, 15f, targetLayer).name);
        return true;
    }
}
