using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveElementReader : MonoBehaviour
{
    Tilemap tilemap;
    [SerializeField] Vector2Int readArea;
    Vector2Int[] directions = new Vector2Int[] { Vector2Int.up, Vector2Int.left, Vector2Int.right, Vector2Int.down };
    WaveFunctionCollapse waveFunctionCollapse;
    Dictionary<Tile, WaveElement> waveElementDictionary = new Dictionary<Tile, WaveElement>();
    WaveElement[,] createdWaves;

    private void Awake()
    {
        createdWaves = new WaveElement[readArea.x, readArea.y];
        waveFunctionCollapse = GetComponentInParent<WaveFunctionCollapse>();
        tilemap = GetComponentInParent<Tilemap>();
    }

    private void OnDrawGizmos() //Al dibujar los Gizmos
    {
        tilemap = GetComponentInParent<Tilemap>();
        Gizmos.color = Color.red; //Se asigna el color
        Vector3Int initialPosition = tilemap.WorldToCell(transform.position) - new Vector3Int(readArea.x / 2, readArea.y / 2, 0); //Se asigna la posici�n inicial
        for (int i = 0; i < readArea.x; i++) //recorrido del eje x del �rea roja del gizmos
        {
            for (int j = 0; j < readArea.y; j++)  //recorrido del eje y del �rea roja del gizmos
            {
                Vector3Int pos = initialPosition + new Vector3Int(i, j, 0); //Se asigna la posici�n
                Gizmos.DrawWireCube(tilemap.GetCellCenterWorld(pos), Vector3.one); //Se dibuja el gizmos en la posici�n calculada arriba
            }
        }
    }

    private void Start() {
        CreateWaveElements();
        waveFunctionCollapse.Collapse(waveElementDictionary.First().Value);
    }

    public void CreateWaveElements()
    {
        Vector3Int initialPosition = tilemap.WorldToCell(transform.position) - new Vector3Int(readArea.x / 2, readArea.y / 2, 0); //Se asigna la posici�n inicial
        for (int i = 0; i < readArea.x; i++) //recorrido del eje x del �rea roja del gizmos
        {
            for (int j = 0; j < readArea.y; j++) //recorrido del eje y del �rea roja del gizmos
            {
                Vector2Int indexPosition = new Vector2Int(i, j); //Se inicializa la posici�n inicial
                Vector3Int pos = initialPosition + new Vector3Int(i, j, 0); //se calcula la posici�n
                Tile tile = tilemap.GetTile<Tile>(pos); //Se obtiene el tile en dicha posici�n
                
                if(tile != null) //Si existe el tile
                {
                    if(!waveElementDictionary.ContainsKey(tile)) //Se comprueba que no haya tile y se crea un nuevo elemento
                    {
                        CreateNewWaveElement(tile, indexPosition);
                    }
                    else //si no se asigna en funci�n de las posiciones
                    {
                        createdWaves[indexPosition.x, indexPosition.y] = waveElementDictionary[tile];
                    }
                }
            }
        }

        for(int i = 0; i < readArea.x; i++) //recorrido del eje x del �rea roja del gizmos
        {
            for(int j = 0; j < readArea.y; j++) //recorrido del eje y del �rea roja del gizmos
            {
                Vector2Int indexPosition = new Vector2Int(i, j); //Se inicializa la posici�n del index
                WaveElement waveElement = createdWaves[indexPosition.x, indexPosition.y]; //Se crea un wave Element en funci�n de dichas posiciones
                if(waveElement != null) //Si no es null
                {
                    waveElement.AddNeighbors(GetNeighbors(indexPosition)); //Se a�ade vecino
                }
            }
        }
    }

    WaveElement[][] GetNeighbors(Vector2Int indexPosition) //M�todo que toma todos los posibles vecinos
    {
        List<WaveElement>[] neighbors = new List<WaveElement>[4]; //Se inicializa el WaveElements

        for (int i = 0; i < 4; i++) //Para cada vecimo de arriba se le asigna una lista
        {
            neighbors[i] = new List<WaveElement>();
        }

        for (int i = 0; i < 4; i++) //Para cada vecino
        {
            Vector2Int newPos = indexPosition + new Vector2Int(directions[i].x, directions[i].y); //Calcula s posici�n
            if(CheckMatrixPos(newPos)) //Si est� en rango
            {
                neighbors[i].Add(createdWaves[newPos.x, newPos.y] != null ? //A�ade
                createdWaves[newPos.x, newPos.y] : //not null
                createdWaves[indexPosition.x, indexPosition.y]); // null
            }
        }

        WaveElement[][] waveNeighbors = new WaveElement[4][]; //Lista a rellenar que se va a devolver
        for (int i = 0; i < 4; i++) //Para cada elemto de la lista
        {
            waveNeighbors[i] = neighbors[i].ToArray(); //A�ade el valor del vecino
        }

        return waveNeighbors; //Devuelve la lista con todos los vecinos
    }

    bool CheckMatrixPos(Vector2Int matrixPos)
    {
        return matrixPos.x >= 0 && matrixPos.x < readArea.x && matrixPos.y >= 0 && matrixPos.y < readArea.y; //Compueba si est� em rango
    }

    void CreateNewWaveElement(Tile tile, Vector2Int indexPosition) //M�todo que genera un nuevo WaveElement en funci�n del tile y la posici�n que les pasemos
    {
        WaveElement waveElement = new WaveElement(tile);
        createdWaves[indexPosition.x, indexPosition.y] = waveElement;
        waveElementDictionary.Add(tile, waveElement);
    }

    void DebugWaveElements()     //M�todo asignado para Debugear el correcto funcionamiento de la lectura
    {
        foreach (WaveElement waveElement in waveElementDictionary.Values)
        {
            Debug.Log(waveElement.Tile.name.ToUpper());
            print("size: " + waveElement.Neighbors.Length);
            Debug.Log("{");
            foreach(WaveElement[] waveElementArray in waveElement.Neighbors)
            {
                Debug.Log("    {");
                if(waveElementArray != null)
                {
                    foreach(WaveElement wave in waveElementArray)
                    {
                        if(wave != null)
                        {
                            Debug.Log(wave.Tile.name);
                        }
                        else
                        {
                            Debug.Log("    null element");
                        }
                    }
                }
                else
                {
                    Debug.Log("   Null Array");
                }
                Debug.Log("    }");
            }
            Debug.Log("}");
            Debug.Log($"\n");
        }
    }
}
