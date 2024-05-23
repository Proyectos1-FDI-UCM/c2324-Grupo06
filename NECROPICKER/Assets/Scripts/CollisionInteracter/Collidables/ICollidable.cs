using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaz que implementan los objetos que tienen comportamiento al colisionar con otros objetos
public interface ICollidable
{
    // Metodo que se llama al colisionar con otro objeto y ejecuta el comportamiento deseado
    void OnCollide(Collider2D other);
}
