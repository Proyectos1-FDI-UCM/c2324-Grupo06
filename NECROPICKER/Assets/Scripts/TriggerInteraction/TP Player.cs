using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlayer : MonoBehaviour 
{
    [SerializeField] private Transform _vector; //Nueva posici�n a la que movemeremos al jugador

    private void OnCollisionEnter2D(Collision2D collision) //M�todo que detecta al jugador
    {
        if (collision.gameObject.TryGetComponent(out InputManager _input)) //Si lo detecta
        {
            collision.transform.position = _vector.position; //Cambia la posici�n del jugador con la que tenemeos referenciada arriba
        }
    }
}
