using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParentItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData; // Datos del item
    public ItemData ItemData => itemData;
    List<IItem> items = new List<IItem>(); // Lista de IItems que contiene el objeto

    [SerializeField] UnityEvent onUse = new UnityEvent();
    public UnityEvent OnUse => onUse;
    // En el Awake, se obtienen todos los IItems que contiene el objeto
    private void Awake() {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponents<IItem>() != null)
            {
                items.AddRange(transform.GetChild(i).GetComponents<IItem>());
            }
        }
    }
    // Al usar el item, se usan todos los IItems que contiene el objeto
    public bool Use(ItemHandler handler)
    {
        onUse?.Invoke();
        UseAllItems(handler);
        return true;
    }
    // Método auxiliar que usa todos los IItems que contiene el objeto
    void UseAllItems(ItemHandler handler)
    {
        if(items == null) return;
        foreach(IItem item in items)
        {
            item.Use(handler);
        }
    }
}
