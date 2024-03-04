using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData;
    public ItemData ItemData => itemData;
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public bool Use(ItemHandler handler)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        return true;
    }
}
