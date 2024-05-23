using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class AutoGraph : MonoBehaviour
{
    [SerializeField] Inventory _inventory; // Inventario al que se añadirán los items
    [SerializeField] ItemData _item; // Item que se añadirá al inventario
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el objeto con el que colisiona tiene un InputManager, se añade el item al inventario asignado y se destruye el objeto
        if (collision.gameObject.TryGetComponent(out InputManager inputManager))
        {
            if (_inventory.AddItem(_item))
            {
                Destroy(gameObject);
            }
        }
    }
}
