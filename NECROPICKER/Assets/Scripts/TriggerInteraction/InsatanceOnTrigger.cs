using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsatanceOnTrigger : MonoBehaviour //Script encargado de instanciar los enemigos en sala al entrar el jugador
{
    [SerializeField] GameObject enemy; //Referencia al enemigo a instanciar
    [SerializeField] GameObject player; //Referencia al jugador
    private void OnTriggerEnter2D(Collider2D collision) //Método que detecta si jugador a entrado o no
    {
        GameObject.Instantiate(enemy); //Si lo detecta Instancia al enemigo
    }
}
