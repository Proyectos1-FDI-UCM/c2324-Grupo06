using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] ItemData _default;
    public ItemData defaultItem 
    {
        get => _default;
        set => _default = value;
    }

    [SerializeField] ItemData _initialItem;
    public ItemData initialItem => _initialItem;

    public IItem selectedItem;
    UnityEvent onItemDrop = new UnityEvent();
    public UnityEvent OnItemDrop => onItemDrop;

    UnityEvent onItemUse = new UnityEvent();
    public UnityEvent OnItemUse => onItemUse;

    private void Awake() {
        if(initialItem != null) SetUpItem(initialItem);
    }

    public void UseItem()
    {
        if(selectedItem != null)
        {
            selectedItem.Use(this);
            onItemUse?.Invoke();
        }
    }

    public void OnItemChanged(ItemData newItem)
    {
        if(newItem == null)
        {
            if(selectedItem != null) Destroy(selectedItem.gameObject);
            selectedItem = null;
            return;
        }
        
        if(selectedItem != null) Destroy(selectedItem.gameObject);

        SetUpItem(newItem);
    }

    void SetUpItem(ItemData newItem)
    {
        GameObject item = Instantiate(newItem.prefab, transform);
        item.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        selectedItem = item.GetComponent<IItem>();
        item.GetComponent<Rigidbody2D>().isKinematic = true;
        item.GetComponent<Rigidbody2D>().drag = 0;
        item.layer = 1;
    }

    public void DropItem()
    {
        if (selectedItem.ItemData != _default)
        {
            selectedItem.gameObject.layer = LayerMask.NameToLayer("Item");
            Rigidbody2D rb = selectedItem.gameObject.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            selectedItem.gameObject.transform.SetParent(null);
            selectedItem = null;
            onItemDrop?.Invoke();
        }
    }
}
