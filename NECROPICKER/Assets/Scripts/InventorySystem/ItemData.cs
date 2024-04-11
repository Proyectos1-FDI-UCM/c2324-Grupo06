using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "InventorySystem/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    [SerializeField] string _itemName;
    public string itemName => _itemName;

    [SerializeField] Sprite _icon;
    public Sprite icon => _icon;

    [SerializeField] GameObject _prefab;
    public GameObject prefab => _prefab;

    [SerializeField] int _maxStackSize;
    public int maxStackSize => _maxStackSize;

    public void SetMaxStackSize(int newSize) => _maxStackSize = newSize;

    [SerializeField] Recipe recipe;
    public Recipe Recipe => recipe;

    [SerializeField] Ingredient[] ingredients;
    public Ingredient[] Ingredients => ingredients;
}

[System.Serializable]
public struct Recipe
{
    [SerializeField] int amount;
    public int Amount => amount;

    [SerializeField] Ingredient[] ingredients;
    public Ingredient[] Ingredients => ingredients;
}


[System.Serializable]
public struct Ingredient
{
    public string ingredientName;
    public int amount;

    public Ingredient(string ingredientName, int amount)
    {
        this.ingredientName = ingredientName;
        this.amount = amount;
    }
}