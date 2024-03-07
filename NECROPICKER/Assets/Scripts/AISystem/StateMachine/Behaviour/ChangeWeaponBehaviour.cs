using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponBehaviour : MonoBehaviour, IBehaviour
{
    private ItemHandler _itemHandler;
    [SerializeField] private ItemData _weapon;

    private void Awake()
    {
        _itemHandler = GetComponentInParent<StateHandler>().GetComponentInChildren<ItemHandler>();
    }

    public void ExecuteBehaviour()
    {
        _itemHandler.OnItemChanged(_weapon);
    }

    private void OnValidate()
    {
        if(_weapon == null) name = $"Disarm";
        else name = $"Change to {_weapon.name}";
    }
}
