using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TileSeter))]
public class DoorIdentifier : MonoBehaviour
{
    private RoomAccess roomAccess;
    private TileSeter _tileSeter;
    private Room _DoorRoom;
    private void Start() => CompareFlag();
    private void Awake()
    {
        _tileSeter = GetComponent<TileSeter>();
        _DoorRoom = GetComponentInParent<Room>();   
    }
    private void CompareFlag() 
    {
        roomAccess = PositionRoomAccess();
        if (_DoorRoom.totalAccess.HasFlag(roomAccess))
        {
            _tileSeter.SetTiles();
            Debug.Log(roomAccess);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private RoomAccess PositionRoomAccess()
    {
        if (Math.Abs(transform.localPosition.x) > Math.Abs(transform.localPosition.y))
        {
            if (transform.localPosition.x > 0) 
            {               
                return RoomAccess.East;
            }
            else 
            {
                return RoomAccess.West;
            }
        }
        else
        {
            if (transform.localPosition.y > 0)
            {
                return RoomAccess.North;
            }
            else
            {
                return RoomAccess.South;
            }
        }
    }
}
