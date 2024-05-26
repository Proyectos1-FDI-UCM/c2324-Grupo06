using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DoorIdentifier : MonoBehaviour
{
    private RoomAccess roomAccess; //Variable que toma las posibles puetas por las que se pueden generar salas
    private Room _DoorRoom;
    [SerializeField] UnityEvent onVerifyIdentity = new UnityEvent(); //Evento que se llama cuando la identidad se identifica
    [SerializeField] UnityEvent onFailIdentity = new UnityEvent(); //Evento que se llama cuando la identidad no se identifica

    private void Start() => CompareFlag();
    private void Awake()
    {
        _DoorRoom = GetComponentInParent<Room>();   
    }
    private void CompareFlag() //Método encargado de comprobar si los accesos coinciden o no con puertas accesibles
    {
        roomAccess = PositionRoomAccess(); //toma las posiciones posibles
        if (_DoorRoom.totalAccess.HasFlag(roomAccess)) //Si de todos los accesos esta el indicado
        {
            onVerifyIdentity?.Invoke(); //Llamado al evento de verificación
        }
        else
        {
            onFailIdentity?.Invoke(); //Si no se llama al evento de no verificación
        }
    }
    private RoomAccess PositionRoomAccess() //Método que saca las posiciones de las puertas de las salas y a raíz de eso saca los posibles roomAcces
    {
        if (Math.Abs(transform.localPosition.x) > Math.Abs(transform.localPosition.y)) //Si la posición en X es mayor que en Y
        {
            if (transform.localPosition.x > 0) //Si es > que 0
            {               
                return RoomAccess.East; //Puerta al este
            }
            else 
            {
                return RoomAccess.West; //Si no puerta al oeste
            }
        }
        else //Si la posición em Y es mayor que en X
        {
            if (transform.localPosition.y > 0) //Si es > 0
            {
                return RoomAccess.North; //Puerta al norte
            }
            else
            {
                return RoomAccess.South; //Si no puerta al sur
            }
        }
    }
}
