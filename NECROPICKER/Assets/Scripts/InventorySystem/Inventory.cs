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
    //busca un item en el inventario en caso de encontrar uno cambia el selectedItemIndex a este
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
    //en caso de q la cantidad de un amount sea 1 que equivale a estar vacio lo cambia por el objeto default
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
    // elimina un item dado su indice
    public void RemoveItemUpgrades(int i)
    {
        if (items[i].item != Default)
        {
                items[i].item = Default;
               
                UpdateInventory();
            
        }
    }
    //Modifica el SelectedItemIndex en funcion de del index que le pasemos al metodo 
    public void SumToIndex(int index) {
        if (SelectedItemIndex + index < 0) SelectedItemIndex = items.Length - 1;
        else if (SelectedItemIndex + index >= items.Length) SelectedItemIndex = 0;
        else SelectedItemIndex += index;
    }
    //Llama al evento on ItemChanged
    public void UpdateInventory() => onItemChanged?.Invoke(items[SelectedItemIndex].item);
    //Vacia el inventario por completo (ya que es un scriptableobject hay que hacerlo a partir de este metodo)
    public void EmptyInventory()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].amount = 1;
            items[i].item = Default;
        }
    }
    //vacia el inventario y lo rellena con el inicial item elegido
    public void RestartWithInitialItem()
    {
        EmptyInventory();
        for (int i = 0; i < numberOfInitials; i++)
        {
            AddItem(initialItem);
        }
    }
    //cambia introduce el nuevo item en el inventario
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







