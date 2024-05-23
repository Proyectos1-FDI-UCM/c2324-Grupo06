using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IItem // Interfaz que deben implementar los items para poder ser usados por el ItemHandler
{
    ItemData ItemData { get; } // Datos del item
    GameObject gameObject { get; } // Objeto que contiene el item
    bool Use(ItemHandler handler); // Método que se llama al usar el item
}
