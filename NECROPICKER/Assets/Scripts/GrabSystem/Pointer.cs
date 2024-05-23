using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Rota el puntero para que apunte en la dirección del vector
    public void SetPointer(Vector2 vector)
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg - 90);
    }
    // Mueve el puntero para que apunte en la dirección del vector y lo rota con ayuda de SetPointer
    public void LookAt(Vector2 position)
    {
        Vector2 vector = position - (Vector2)transform.position;
        vector.Normalize();

        SetPointer(vector);
    }
    // Dirección por defecto del puntero
    public Vector2 GetDirection()
    {
        return transform.up;
    }
}
