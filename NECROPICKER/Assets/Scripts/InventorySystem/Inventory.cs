using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "InventorySystem/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    public ItemData[] items = new ItemData[5];
    [SerializeField] ItemData Necronomicon;
    [SerializeField] int _selectedItemIndex = 0;
    public int SelectedItemIndex
    {
        get => _selectedItemIndex;
        private set
        {
            Debug.Log(value);
            _selectedItemIndex = value;
            UpdateInventory();
        }
    }

    UnityEvent<ItemData> onItemChanged = new UnityEvent<ItemData>();
    public UnityEvent<ItemData> OnItemChanged => onItemChanged;

    public bool AddItem(ItemData itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == Necronomicon)
            {
                if(items[SelectedItemIndex] == Necronomicon) SelectedItemIndex = i;
                items[i] = itemToAdd;
                UpdateInventory();
                return true;
            }
        }
        return false;
    }

    void LookForAnItem()
    {
        if(items[SelectedItemIndex] != Necronomicon) return;

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != Necronomicon)
            {
                Debug.Log(i);
                Debug.Log(items[i]);
                SelectedItemIndex = i;
                return;
            }
        }
    }

    public void RemoveItem()
    {
        items[SelectedItemIndex] = Necronomicon;
        UpdateInventory();
    }

    public void SumToIndex(int index) {
        if (SelectedItemIndex + index < 0) SelectedItemIndex = items.Length - 1;
        else if (SelectedItemIndex + index >= items.Length) SelectedItemIndex = 0;
        else SelectedItemIndex += index;
    }

    public void UpdateInventory()
    { 
        LookForAnItem();
        onItemChanged?.Invoke(items[SelectedItemIndex]);
    }
}
