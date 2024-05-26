using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags] public enum RoomAccess //Indicadores para averiguar que tipo de sala es
{
    None = 0,
    North = 1,
    East = 2,
    South = 4,
    West = 8
}

public class Room : MonoBehaviour
{
    [SerializeField] RoomAccess _totalAccess; //Accesos totales que se encuentran serializados
    public RoomAccess totalAccess => _totalAccess; //Constructora

    private void Update() {
        foreach(RoomAccess access in GetAllAccess())
        {
            Vector2 debugDirection = AccessValueToVector2(access);
            Debug.DrawRay(transform.position, new Vector2(debugDirection.x, debugDirection.y) * 10, Color.red); 
        }
    }
    Vector2Int AccessValueToVector2(RoomAccess accessValue) //Método encargado de asignar un valor a los access
    {
        switch (accessValue)
        {
            case RoomAccess.North:
                return new Vector2Int(0, 1);
            case RoomAccess.East:
                return new Vector2Int(1, 0);
            case RoomAccess.South:
                return new Vector2Int(0, -1);
            case RoomAccess.West:
                return new Vector2Int(-1, 0);
            default:
                return Vector2Int.zero;
        }
    }

    public RoomAccess[] GetAllAccess() //Método encargado de devolver los posibles accesos de la sala
    {
        List<RoomAccess> accessList = new List<RoomAccess>(); //Variable donde se almacenaran todos los roomAccess
        foreach(RoomAccess access in Enum.GetValues(typeof(RoomAccess))) //Se recorren todos los roomAccess
        {
            if(_totalAccess.HasFlag(access)) accessList.Add(access); //Si coincide con alguno se le añade al accessList
        }
        return accessList.ToArray(); //Devuelve la lista con todos los roomAccess
    }

    public void SetAccess(RoomAccess roomAccess) => _totalAccess = roomAccess; //Setea el total de accesos de la sala
}
