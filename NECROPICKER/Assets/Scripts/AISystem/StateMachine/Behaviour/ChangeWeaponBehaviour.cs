using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponBehaviour : MonoBehaviour, IBehaviour
{
    private ItemHandler _itemHandler;
    [SerializeField] private ItemData _weapon;

    private void Awake()
    {
        _itemHandler = GetComponentInParent<ItemHandler>();
    }

    public void ExecuteBehaviour()
    {
        _itemHandler.OnItemChanged(_weapon);
    }

    private void OnValidate()
    {
        name = $"Change to {_weapon.name}";
    }
}
