using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParentItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData;
    public ItemData ItemData => itemData;
    List<IItem> items = new List<IItem>();

    [SerializeField] UnityEvent onUse = new UnityEvent();
    public UnityEvent OnUse => onUse;

    private void Awake() {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent(out IItem item))
                items.Add(item);
        }
    }

    public bool Use(ItemHandler handler)
    {
        onUse?.Invoke();
        UseAllItems(handler);
        return true;
    }

    void UseAllItems(ItemHandler handler)
    {
        if(items == null) return;
        foreach(IItem item in items)
        {
            item.Use(handler);
        }
    }
}
