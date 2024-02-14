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
}