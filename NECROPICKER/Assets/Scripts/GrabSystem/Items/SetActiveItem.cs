using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData; // Datos del item
    public ItemData ItemData => itemData;
    // En el Awake, se desactivan todos los hijos del objeto que contiene el script
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    // Al usar el item, se activan todos los hijos del objeto que contiene el script
    public bool Use(ItemHandler handler)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        return true;
    }
}
