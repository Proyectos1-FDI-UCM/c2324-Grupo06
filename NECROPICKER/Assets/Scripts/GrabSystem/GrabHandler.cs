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
    IItem TakeAbleItem
    {
        set
        {
            if(takeAbleItem != value)
            {
                if (takeAbleItem != null) onItemDeselected.Invoke(takeAbleItem.gameObject);

                if(value != null) onItemSelected.Invoke(value.gameObject);

                takeAbleItem = value;
            }
        }
    }

    #region Events
    UnityEvent<GameObject> onItemSelected = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> OnItemSelected => onItemSelected;

    UnityEvent<GameObject> onItemDeselected = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> OnItemDeselected => onItemDeselected;

    [SerializeField] UnityEvent onFullInventory = new UnityEvent();

    UnityEvent onItemTaken = new UnityEvent();
    public UnityEvent OnItemTaken => onItemTaken;
    #endregion

    private void Awake()
    {
        itemLayer = LayerMask.GetMask("Item");
    }

    private void Update() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.up * grabOffset, grabRadius, itemLayer);

        if(hit == null)
        {
            TakeAbleItem = null;
            return;
        }

        if(hit.TryGetComponent(out IItem item))
        {
            TakeAbleItem = item;
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
                TakeAbleItem = null;
                onItemTaken.Invoke();
            }
            else
            {
                onFullInventory.Invoke();
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.up * grabOffset, grabRadius);
    }
}
