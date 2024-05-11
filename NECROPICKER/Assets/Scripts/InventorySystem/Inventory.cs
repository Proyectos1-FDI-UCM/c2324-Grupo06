using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;
//using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Inventory", menuName = "InventorySystem/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    [SerializeField] public ItemStack[] items = new ItemStack[5];
    
    [SerializeField] ItemData Default;
    [SerializeField] int _selectedItemIndex = 0;
    [SerializeField] ItemData initialItem;
    [SerializeField] int numberOfInitials;

    private void Awake()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].item = Default;
        }
        UpdateInventory();
    }
    public int SelectedItemIndex
    {
        get => _selectedItemIndex;
        private set
        {
            _selectedItemIndex = value;
            UpdateInventory();
        }
    }
   
    UnityEvent<ItemData> onItemChanged = new UnityEvent<ItemData>();
    public UnityEvent<ItemData> OnItemChanged => onItemChanged;

    UnityEvent<ItemData> onDefaultChanged = new UnityEvent<ItemData>();
    public UnityEvent<ItemData> OnDefaultChanged => onDefaultChanged;

    public bool HasItem(ItemData itemData)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item == itemData) return true;
        }
        return false;
    }

    public void AddItemNonReturn(ItemData itemToAdd) => AddItem(itemToAdd);

    public bool AddItem(ItemData itemToAdd)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i].item == itemToAdd && items[i].amount < items[i].item.maxStackSize)
            {
                items[i].amount++;
                UpdateInventory();
                return true;
            }
        } 
        
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item == Default)
            {
                if(items[SelectedItemIndex].item == Default) SelectedItemIndex = i;
                items[i].item = itemToAdd;
                items[i].amount = 1;
                
                UpdateInventory();
                return true;
            }
            
        }
        return false;
    }

    void LookForAnItem()
    {
        if(items[SelectedItemIndex].item != Default) return;

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item != Default)
            {
                SelectedItemIndex = i;
                return;
            }
        }

        UpdateInventory();
    }

    public void RemoveItem()
    {
        if (items[SelectedItemIndex].item != Default)
        {
            if (items[SelectedItemIndex].amount == 1)
            {
                items[SelectedItemIndex].item = Default;
                LookForAnItem();
            }
            else 
            {
                items[SelectedItemIndex].amount--;
                UpdateInventory();
            }
        }
    }
    public void RemoveItemUpgrades(int i)
    {
        if (items[i].item != Default)
        {
                items[i].item = Default;
               // LookForAnItem();
                UpdateInventory();
            
        }
    }

    public void SumToIndex(int index) {
        if (SelectedItemIndex + index < 0) SelectedItemIndex = items.Length - 1;
        else if (SelectedItemIndex + index >= items.Length) SelectedItemIndex = 0;
        else SelectedItemIndex += index;
    }

    public void UpdateInventory() => onItemChanged?.Invoke(items[SelectedItemIndex].item);

    public void EmptyInventory()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].amount = 1;
            items[i].item = Default;
        }
    }

    public void RestartWithInitialItem()
    {
        EmptyInventory();
        for (int i = 0; i < numberOfInitials; i++)
        {
            AddItem(initialItem);
        }
    }

    public void ChangeDefault(ItemData itemData)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i].item = Default) items[i].item = itemData;
        }
        UpdateInventory();
        Default = itemData;
        OnDefaultChanged?.Invoke(itemData);
    }
}

 [System.Serializable] public struct ItemStack
 {
     public ItemData item;
     public int amount;

     public ItemStack(ItemData item, int amount)
     {
        this.item = item;
        this.amount = amount;
     }
 }







/*
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

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
                if (items[SelectedItemIndex] == Necronomicon) SelectedItemIndex = i;
                items[i] = itemToAdd;
                UpdateInventory();
                return true;
            }
        }
        return false;
    }

    void LookForAnItem()
    {
        if (items[SelectedItemIndex] != Necronomicon) return;

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != Necronomicon)
            {
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

    public void SumToIndex(int index)
    {
        if (SelectedItemIndex + index < 0) SelectedItemIndex = items.Length - 1;
        else if (SelectedItemIndex + index >= items.Length) SelectedItemIndex = 0;
        else SelectedItemIndex += index;
    }

    public void UpdateInventory()
    {
        LookForAnItem();
        onItemChanged?.Invoke(items[SelectedItemIndex]);
    }
}*/