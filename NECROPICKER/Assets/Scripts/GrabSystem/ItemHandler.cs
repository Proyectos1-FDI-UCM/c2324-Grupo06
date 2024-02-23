using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] ItemData _initialItem;
    public ItemData initialItem => _initialItem;

    public IItem selectedItem;
    UnityEvent onItemDrop = new UnityEvent();
    public UnityEvent OnItemDrop => onItemDrop;

    private void Awake() {
        if(initialItem != null) SetUpItem(initialItem);
    }

    public void UseItem()
    {
        if(selectedItem != null)
        {
            selectedItem.Use(this);
        }
    }

    public void OnItemChanged(ItemData newItem)
    {
        //print("ItemChsnged");
        if(selectedItem != null) Destroy(selectedItem.gameObject);

        SetUpItem(newItem);
    }

    void SetUpItem(ItemData newItem)
    {
        GameObject item = Instantiate(newItem.prefab, transform);
        item.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        selectedItem = item.GetComponent<IItem>();
        item.GetComponent<Rigidbody2D>().isKinematic = true;
        item.layer = 1;
    }

    public void DropItem()
    {
        selectedItem.gameObject.layer = LayerMask.NameToLayer("Item");
        Rigidbody2D rb = selectedItem.gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        selectedItem.gameObject.transform.SetParent(null);
        selectedItem = null; 
        onItemDrop?.Invoke();
    }
}
