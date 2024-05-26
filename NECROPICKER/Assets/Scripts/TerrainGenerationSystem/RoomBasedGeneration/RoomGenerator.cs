using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RoomGenerator : MonoBehaviour //Script encargado de la generación de salas en función del tipo de sala
{
    [SerializeField] RoomSetting initialRoom; 
    RoomSettingStack roomSettings;
    [SerializeField] RoomSetting[] Rooms;
    RoomSetting[,] createdRooms = new RoomSetting[100, 100];
    List<Vector2Int> roomPositions = new List<Vector2Int>();
    List<Vector2Int> lastRoomsPositions = new List<Vector2Int>();
    [SerializeField] Vector2Int roomSize = new Vector2Int();
    [SerializeField] int maxRoomExtension = 40;
    int extensionCounter = 0;


    [SerializeField] UnityEvent onLoading = new UnityEvent(); //Evento de Unity que se llama en la pantalla de carga
    public UnityEvent OnLoading => onLoading;

    [SerializeField] UnityEvent onLoaded = new UnityEvent(); //Evento que se llama una vez termina la pantalla de carga
    public UnityEvent OnLoaded => onLoaded;

    private void Awake()
    {
        roomSettings = new RoomSettingStack(Rooms);
        transform.position = new Vector2(createdRooms.GetLength(0) / 2 * roomSize.x, createdRooms.GetLength(1) / 2 * roomSize.y);
        GenerateRoom((int)transform.position.x / roomSize.x, (int)transform.position.y / roomSize.y, initialRoom, (RoomAccess)15);
        StartCoroutine(GenerateRooms());
    }

    private void Start() => onLoading?.Invoke(); //pantalla de carga

    RoomSetting GenerateRandomRoom(int x, int y, RoomAccess accessValue) //Método encargado de generar salas aleatorias
    {
        RoomSetting newRoom = ReturnRandomRoom(x, y, roomSettings); //Guardamos una sala aleatoria

        newRoom.Room.SetAccess(ReturnRandomAccess(accessValue)); //Sacamos sus valores
        lastRoomsPositions.Add(new Vector2Int(x, y)); //Añadimos la posición del room que sse acaba de generar
        createdRooms[x, y] = newRoom; //Se añade a la matriz de salas generadas
        extensionCounter++; //ExtensionCounter = ExtensionCounter + 1
        return newRoom; //Devolvemos la sala generada
    }

    RoomSetting GenerateStrictRoom(int x, int y, RoomAccess accessValue, RoomSettingStack roomSettings) //Método encargado de generar las salas obligatorias ( cambio de piso, mejoras)
    {
        RoomSetting newRoom = ReturnRandomRoom(x, y, roomSettings); //Guardamos la sala
        newRoom.Room.SetAccess(accessValue); //Sacamos sus valores
        createdRooms[x, y] = newRoom; //Se añade a la matriz de salas generadas
        return newRoom; //Devolvemos la sala generada
    }
    RoomSetting ReturnRandomRoom(int x, int y, RoomSettingStack roomSettingStack) //Método encargado de devolver una sala aleatoria
    {
        RoomSetting randomRoom = roomSettingStack.RandomRoomSetting(); //Sacamos una sala aleatoria

        GameObject newRoomGameObject = Instantiate(randomRoom.RoomPrefab, new Vector2(x * roomSize.x, y * roomSize.y), Quaternion.identity); //Creamos un GameObject de tipo sala
        RoomSetting newRoom = new RoomSetting(newRoomGameObject, randomRoom.Probability, randomRoom.MinNumOfInstances); //Creamos la nueva sala con el GameObject y el roomSettings
        return newRoom; //Devolvemos la sala generada
    }

    RoomAccess ReturnRandomAccess(RoomAccess accesValue) //Método encargado de devolver un acceso de la sala aleatorio siguiendo los Flags de Acces
    {
        RoomAccess newAccess = (RoomAccess)Random.Range(1, 15); //Se crea el acceso aleatorio
        while (accesValue == newAccess) //Si coinciden se pide otro aleatorio
        {           
            newAccess = (RoomAccess)Random.Range(1, 15);
        }
        accesValue |= newAccess; //Cuando no coinciden
        return accesValue; //Devolvemos el acces value modificado
    }
    
    void GenerateRoom(int x, int y, RoomSetting room, RoomAccess roomAccess) // Método encargado de generar la sala Inicial
    {
        GameObject newRoomGameObject = Instantiate(room.RoomPrefab, new Vector2(x * roomSize.x, y * roomSize.y), Quaternion.identity); //Nos creamos el GameObject de tipo sala
        RoomSetting newRoom = new RoomSetting(newRoomGameObject, room.Probability, room.MinNumOfInstances); //Creamos una nueva sala en función del GameObject
        newRoom.Room.SetAccess(roomAccess); //Sacamos los posibles Accesos
        lastRoomsPositions.Add(new Vector2Int(x, y)); //Añadimos a la última posición la posición de esta sala
        createdRooms[x, y] = newRoom; //Se añade a la matriz de salas generadas
        extensionCounter++;  //ExtensionCounter = ExtensionCounter + 1
    }

    RoomAccess OppossiteAccess(RoomAccess accessValue) //Método que devuelve la puerta oopuesta a la que se le pasa
    {
        switch (accessValue) //Si el roomAcces es:
        {
            case RoomAccess.North: //Norte
                return RoomAccess.South; //Devuelve Sur
            case RoomAccess.East: //Este
                return RoomAccess.West; //Devuelve oeste
            case RoomAccess.South: //Sur
                return RoomAccess.North;//Devuelve norte
            case RoomAccess.West://Oeste
                return RoomAccess.East; //Devuelve este
            default: //Si no es ninguna de las 4
                return RoomAccess.None; //devueleve vacío
        }
    }

    bool CheckPosition(int x, int y) => createdRooms[x, y] == null; //método que Checkea la posición y comprueba que tenga valor

    Vector2Int AccessValueToVector2(RoomAccess accessValue) //Método encargado de obtener una posición vectorial en función de las puertas que posea la sala
    {
        switch (accessValue) //Si el roomAcces es:
        {
            case RoomAccess.North: //Norte
                return new Vector2Int(0, 1); //Genera el vector (0,1)
            case RoomAccess.East: //Este
                return new Vector2Int(1, 0); //Genera el vector (1,0)
            case RoomAccess.South: //Sur
                return new Vector2Int(0, -1); //Genera el vector (0,-1)
            case RoomAccess.West: //Oeste
                return new Vector2Int(-1, 0); //Genera el vector (-1,0)
            default: //Si no es ninguna de las 4
                return Vector2Int.zero; //Genera el vector (0,0)
        }
    }

    IEnumerator GenerateRooms() //Método que genera el conjunto global de salas del piso 
    {
        while(lastRoomsPositions.Count > 0) //Mientras queden salas por colocar
        {
            Vector2Int[] roomPositions = lastRoomsPositions.ToArray(); //Creacción de un array para guardar las posiciones de las salas generadas
            lastRoomsPositions.Clear(); //Limpiamos el valor que se encontrara en la última posición

            foreach(Vector2Int _roomPosition in roomPositions) //Para cada roomPosition del array de roomPositions
            {
                Room selectedRoom = createdRooms[_roomPosition.x, _roomPosition.y].Room; //creamos una variable de room y le asignamos el valor de la sala generada
                if(extensionCounter < maxRoomExtension) // Si no supera el máximo de salas permitido    
                {
                    foreach (RoomAccess access in selectedRoom.GetAllAccess()) //Para cada acceso de la sala seleccionada
                    {
                        Vector2Int direction = AccessValueToVector2(access); //Tomamos la dirección del acceso seleccionado
                        Vector2Int nextRoomPosition = _roomPosition + direction; //Guardamos la posición de la puerta transitoria de la sala anterior con la nueva sala
                        RoomAccess nextRoomAccess = OppossiteAccess(access); //Asignamos el acceso de la nueva sala
                        if (CheckPosition(nextRoomPosition.x, nextRoomPosition.y)) //Si hay valor en la posición
                        {
                            GenerateRandomRoom(nextRoomPosition.x, nextRoomPosition.y, nextRoomAccess); //Genera la sala aleatorio
                        }
                        else if(!createdRooms[nextRoomPosition.x, nextRoomPosition.y].Room.totalAccess.HasFlag(nextRoomAccess)) //Si no detecta la bandera correspondiente
                        {
                            RoomAccess fixedAccess = createdRooms[nextRoomPosition.x, nextRoomPosition.y].Room.totalAccess | nextRoomAccess; //Se corrige el acceso
                            Destroy(createdRooms[nextRoomPosition.x, nextRoomPosition.y].Room.gameObject); //Se destruye la sala que no sirve
                            GenerateStrictRoom(nextRoomPosition.x, nextRoomPosition.y, fixedAccess, roomSettings); //Se genera una sala obligatoria en su lugar
                        }
                    }
                }
                else //Si supera el máximo
                {
                    foreach (RoomAccess access in selectedRoom.GetAllAccess()) //Para cada acceso de la sala seleccionada
                    {
                        Vector2Int direction = AccessValueToVector2(access); //Tomamos la dirección del acceso seleccionado
                        Vector2Int nextRoomPosition = _roomPosition + direction; //Guardamos la posición de la puerta transitoria de la sala anterior con la nueva sala
                        RoomAccess nextRoomAccess = OppossiteAccess(access);//Asignamos el acceso de la nueva sala
                        if (CheckPosition(nextRoomPosition.x, nextRoomPosition.y)) //Si hay valor en la posición
                        {
                            GenerateStrictRoom(nextRoomPosition.x, nextRoomPosition.y, nextRoomAccess, roomSettings); //Genera la posicióna laeatoria
                            this.roomPositions.Add(nextRoomPosition); //Se añade la posición de nextroomposition en la lista de room position
                        }
                        else if (!createdRooms[nextRoomPosition.x, nextRoomPosition.y].Room.totalAccess.HasFlag(nextRoomAccess))//Si no detecta la bandera correspondiente
                        {
                            RoomAccess fixedAccess = createdRooms[nextRoomPosition.x, nextRoomPosition.y].Room.totalAccess | nextRoomAccess; //Se corrige el acceso
                            Destroy(createdRooms[nextRoomPosition.x, nextRoomPosition.y].Room.gameObject); //Se destruye la sala que no sirve
                            GenerateStrictRoom(nextRoomPosition.x, nextRoomPosition.y, fixedAccess, roomSettings); //Se genera una sala obligatoria en su lugar
                        }
                    }
                }
            }

            yield return new WaitForSeconds(1.01f); //Espera 1 segundo
        }
        //FIN DEL BUCLE
        foreach(RoomSetting roomSetting in roomSettings.RoomSettings) //Para cada roomSetting del roomSetting
        {
            if(roomSettings.RoomSettingInstances[roomSetting] < roomSetting.MinNumOfInstances) //Si las instancias del roomSettings son menores que el mínimo de instancias
            {
                //Para cada roomSetting elimina las salas que no sirven y genera unas que si en su lugar
                for(int i = 0; i < roomSetting.MinNumOfInstances - roomSettings.RoomSettingInstances[roomSetting]; i++)
                {
                    Vector2Int randomRoomPosition;
                    randomRoomPosition = roomPositions[Random.Range(0, roomPositions.Count)];
                    
                    RoomAccess access = createdRooms[randomRoomPosition.x, randomRoomPosition.y].Room.totalAccess;
                    Destroy(createdRooms[randomRoomPosition.x, randomRoomPosition.y].Room.gameObject);
                    GenerateRoom(randomRoomPosition.x, randomRoomPosition.y, roomSetting, access);

                    roomPositions.Remove(randomRoomPosition);
                }
            }
        }
        //desactivar Pantalla de carga
        onLoaded?.Invoke();
    }
}

[System.Serializable]
public class RoomSetting //Clase que corresponde a la configuración de las slas
{
    [SerializeField] GameObject roomPrefab;
    public GameObject RoomPrefab => roomPrefab;

    Room room;
    public Room Room => room;

    [Range(0,1)] 
    [SerializeField] float probability;
    public float Probability => probability;

    [SerializeField] int minNumOfInstances;
    public int MinNumOfInstances => minNumOfInstances;

    public RoomSetting(GameObject roomPrefab, float probability, int minNumOfInstances) //Constructora
    {
        this.roomPrefab = roomPrefab;
        this.probability = probability;
        this.minNumOfInstances = minNumOfInstances;
        room = roomPrefab.GetComponent<Room>();
    }

    public void SetProbability(float probability) => this.probability = probability; //Método encargado de setear la probabilidad de las salas
}

[System.Serializable]
public class RoomSettingStack //Clase que corresponde con el conjunto de roomSettings (un roomSetting por sala generada)
{
    [SerializeField] RoomSetting[] roomSettings;
    public RoomSetting[] RoomSettings => roomSettings;

    Dictionary<RoomSetting, int> roomSettingInstances = new Dictionary<RoomSetting, int>();
    public Dictionary<RoomSetting, int> RoomSettingInstances => roomSettingInstances;

    public RoomSettingStack(RoomSetting[] roomSettings) //Constructora añade al conjunto de roomSettings los roomSettings
    {
        this.roomSettings = roomSettings;

        foreach(RoomSetting roomSetting in roomSettings)
        {
            roomSettingInstances.Add(roomSetting, 0);
        }
    }

    public RoomSetting RandomRoomSetting() //Método que genera una configuración aleatoria
    {
        float randomValue = Random.value; //Se calcula un valor aleatorio
        float probabilitySum = 0; //Variable que almacena la probabilidad total
        foreach(RoomSetting roomSetting in roomSettings) //Para cada roomSetting del roomSetting
        {
            probabilitySum += roomSetting.Probability; //Se calcula la probabilidad total
            if(randomValue <= probabilitySum) //Si el valor aleatorio generado es menor que la asignada
            {
                roomSettingInstances[roomSetting]++; //roomSettingInstances[roomSetting] = roomSettingInstances[roomSetting] + 1
                return roomSetting; //Devuelves el roomSetting generado
            }
        }
        roomSettingInstances[roomSettings[roomSettings.Length - 1]]++;//roomSettingInstances[roomSetting.Length - 1] = roomSettingInstances[roomSetting.Length - 1] + 1
        return roomSettings[roomSettings.Length - 1]; //Devuelve el último roomSetting generado
    }
}