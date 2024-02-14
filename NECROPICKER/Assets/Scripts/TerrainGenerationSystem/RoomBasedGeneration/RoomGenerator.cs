using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] GameObject initialRoom;
    bool nextFloorRoomGenerated = false;
    [SerializeField] GameObject[] nextFloorRooms;

    [SerializeField] GameObject[] roomPrefabs;
    [SerializeField] GameObject[] strictRoomPrefabs;

    Room[,] createdRooms = new Room[100, 100];
    List<Vector2Int> lastRoomsPositions = new List<Vector2Int>();
    const int roomSize = 20;
    [SerializeField] int maxRoomExtension = 40;
    int extensionCounter = 0;

    private void Awake(){
        transform.position = new Vector2(createdRooms.GetLength(0) / 2 * roomSize, createdRooms.GetLength(1) / 2 * roomSize);
        GenerateRoom((int)transform.position.x / roomSize, (int)transform.position.y / roomSize, initialRoom);
        GenerateRooms();
    }

    Room GenerateRoom(int x, int y, RoomAccess accessValue)
    {
        Room newRoom = Instantiate(ReturnRandomRoom(accessValue) , new Vector2(x * roomSize, y * roomSize), Quaternion.identity).GetComponent<Room>();
        lastRoomsPositions.Add(new Vector2Int(x, y));
        createdRooms[x, y] = newRoom;
        extensionCounter++;

        return newRoom;
    }

    void GenerateRoom(int x, int y, GameObject room)
    {
        Room newRoom = Instantiate(room , new Vector2(x * roomSize, y * roomSize), Quaternion.identity).GetComponent<Room>();
        lastRoomsPositions.Add(new Vector2Int(x, y));
        createdRooms[x, y] = newRoom;
        extensionCounter++;
    }

    Room GenerateStrictRoom(int x, int y, RoomAccess accessValue, GameObject[] roomsToTakeFrom)
    {
        Room newRoom = Instantiate(ReturnStrictRandomRoom(accessValue, roomsToTakeFrom) , new Vector2(x * roomSize, y * roomSize), Quaternion.identity).GetComponent<Room>();
        createdRooms[x, y] = newRoom;
        return newRoom;
    }

    RoomAccess OppossiteAccess(RoomAccess accessValue)
    {
        switch (accessValue)
        {
            case RoomAccess.North:
                return RoomAccess.South;
            case RoomAccess.East:
                return RoomAccess.West;
            case RoomAccess.South:
                return RoomAccess.North;
            case RoomAccess.West:
                return RoomAccess.East;
            default:
                return RoomAccess.None;
        }
    }

    GameObject ReturnRandomRoom(RoomAccess accessValue)
    {
        List<GameObject> possibleRooms = new List<GameObject>();
        foreach (GameObject room in roomPrefabs)
        {
            Room roomScript = room.GetComponent<Room>();
            if (roomScript.totalAccess.HasFlag(accessValue))
            {
                possibleRooms.Add(room);
            }
        }
        return possibleRooms[Random.Range(0, possibleRooms.Count)];
    }

    GameObject ReturnStrictRandomRoom(RoomAccess accessValue, GameObject[] roomsToTakeFrom)
    {
        List<GameObject> possibleRooms = new List<GameObject>();
        foreach (GameObject room in roomsToTakeFrom)
        {
            Room roomScript = room.GetComponent<Room>();
            if (roomScript.totalAccess == accessValue)
            {
                print("Room found!");
                possibleRooms.Add(room);
            }
        }
        print(possibleRooms.Count);
        print(accessValue);
        print(possibleRooms[0]);
        return possibleRooms[Random.Range(0, possibleRooms.Count)];
    }

    bool CheckPosition(int x, int y) => createdRooms[x, y] == null;

    Vector2Int AccessValueToVector2(RoomAccess accessValue)
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

    void GenerateRooms()
    {
        while(lastRoomsPositions.Count > 0)
        {
            Vector2Int[] roomPositions = lastRoomsPositions.ToArray();
            lastRoomsPositions.Clear();

            foreach(Vector2Int _roomPosition in roomPositions)
            {
                Room selectedRoom = createdRooms[_roomPosition.x, _roomPosition.y];
                if(extensionCounter < maxRoomExtension)
                {
                    foreach (RoomAccess access in selectedRoom.GetAllAccess())
                    {
                        Vector2Int direction = AccessValueToVector2(access);
                        Vector2Int nextRoomPosition = _roomPosition + direction;
                        RoomAccess nextRoomAccess = OppossiteAccess(access);

                        if (CheckPosition(nextRoomPosition.x, nextRoomPosition.y))
                        {
                            GenerateRoom(nextRoomPosition.x, nextRoomPosition.y, nextRoomAccess);
                        }
                        else if(!createdRooms[nextRoomPosition.x, nextRoomPosition.y].totalAccess.HasFlag(nextRoomAccess))
                        {
                            RoomAccess fixedAccess = createdRooms[nextRoomPosition.x, nextRoomPosition.y].totalAccess | nextRoomAccess;
                            Destroy(createdRooms[nextRoomPosition.x, nextRoomPosition.y].gameObject);
                            GenerateStrictRoom(nextRoomPosition.x, nextRoomPosition.y, fixedAccess, strictRoomPrefabs);
                        }
                    }
                }
                else
                {
                    foreach (RoomAccess access in selectedRoom.GetAllAccess())
                    {
                        Vector2Int direction = AccessValueToVector2(access);
                        Vector2Int nextRoomPosition = _roomPosition + direction;
                        RoomAccess nextRoomAccess = OppossiteAccess(access);


                        if (CheckPosition(nextRoomPosition.x, nextRoomPosition.y))
                        {
                            if(!nextFloorRoomGenerated)
                            {
                                nextFloorRoomGenerated = true;
                                GenerateStrictRoom(nextRoomPosition.x, nextRoomPosition.y, nextRoomAccess, nextFloorRooms);
                            }
                            else
                            {
                                GenerateStrictRoom(nextRoomPosition.x, nextRoomPosition.y, nextRoomAccess, strictRoomPrefabs);
                            }
                        }
                        else
                        {
                            RoomAccess fixedAccess = createdRooms[nextRoomPosition.x, nextRoomPosition.y].totalAccess | nextRoomAccess;
                            Destroy(createdRooms[nextRoomPosition.x, nextRoomPosition.y].gameObject);
                            GenerateStrictRoom(nextRoomPosition.x, nextRoomPosition.y, fixedAccess, strictRoomPrefabs);
                        }
                    }
                }
            }
        }
    }
}
