using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

//Este script se encarga de que la cámara siga al jugador. Al iniciar (Start),
//encuentra el InputManager en la escena y obtiene su Transform.
//El método LookAtPlayer actualiza la posición de la cámara para que coincida con
//la posición del jugador en los ejes x e y, manteniendo la misma coordenada z.

public class PlayerCameraFollower : MonoBehaviour
{
    Transform player;
    private void Start()
    {
        player = FindObjectOfType<InputManager>().transform;
    }

    public void LookAtPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
