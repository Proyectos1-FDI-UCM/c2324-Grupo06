using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabHandler : MonoBehaviour
{
    LayerMask itemLayer;
    [SerializeField] float grabRadius = 2f;
    [SerializeField] float grabOffset = 1f;
    [SerializeField] Inventory _inventory;
    IItem takeAbleItem;

    private void Awake()
    {
        itemLayer = LayerMask.GetMask("Item");
    }

    private void Update() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.up * grabOffset, grabRadius, itemLayer);

        if(hit == null)
        {
            takeAbleItem = null;
            return;
        }

        if(hit.TryGetComponent(out IItem item))
        {
            takeAbleItem = item;
        }
    }

    public void TakeItem()
    {
        if(takeAbleItem != null) 
        {
            if(_inventory.AddItem(takeAbleItem.ItemData))
            {
                _inventory.UpdateInventory();
                Destroy(takeAbleItem.gameObject);
                takeAbleItem = null;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.up * grabOffset, grabRadius);
    }
}
