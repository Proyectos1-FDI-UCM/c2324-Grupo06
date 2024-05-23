using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTargetItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData; // Datos del item
    public ItemData ItemData => itemData;
    private Transform target; // Objetivo seleccionado
    [SerializeField]
    LayerMask targetLayer; // Capa de los objetos que pueden ser seleccionados
    TargetHandler targetHandler; // Componente que maneja el objetivo seleccionado

    [SerializeField] float radius = 100f; // Radio en el que se buscan objetivos

    private void Awake()
    {
        targetHandler = GetComponent<TargetHandler>();
    }

    // Al usar el item, se selecciona un objetivo en un radio determinado
    public bool Use(ItemHandler handler)
    {
        try
        {
            //Busca un objetivo en un radio determinado
            target = Physics2D.OverlapCircle(transform.position, radius, targetLayer).transform;
        }
        catch
        {
            //Si no encuentra un objetivo, selecciona el objetivo más cercano en la dirección en la que mira el objeto que contiene el item
            target = Physics2D.Raycast(transform.position, transform.up, 200f).transform;
        }
        
        targetHandler.SetTarget(target); // Actualiza el objetivo seleccionado

        return true;
    }
}
