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

    private void OnDrawGizmos() {
        tilemap = GetComponentInParent<Tilemap>();
        Gizmos.color = Color.red;
        Vector3Int initialPosition = tilemap.WorldToCell(transform.position) - new Vector3Int(readArea.x / 2, readArea.y / 2, 0);
        for (int i = 0; i < readArea.x; i++)
        {
            for (int j = 0; j < readArea.y; j++)
            {
                Vector3Int pos = initialPosition + new Vector3Int(i, j, 0);
                Gizmos.DrawWireCube(tilemap.GetCellCenterWorld(pos), Vector3.one);
            }
        }
    }

    private void Start() {
        CreateWaveElements();
        // DebugWaveElements();
        waveFunctionCollapse.Collapse(waveElementDictionary.First().Value);
    }

    public void CreateWaveElements()
    {
        Vector3Int initialPosition = tilemap.WorldToCell(transform.position) - new Vector3Int(readArea.x / 2, readArea.y / 2, 0);
        for (int i = 0; i < readArea.x; i++)
        {
            for (int j = 0; j < readArea.y; j++)
            {
                Vector2Int indexPosition = new Vector2Int(i, j);
                Vector3Int pos = initialPosition + new Vector3Int(i, j, 0);
                Tile tile = tilemap.GetTile<Tile>(pos);
                
                if(tile != null)
                {
                    if(!waveElementDictionary.ContainsKey(tile))
                    {
                        CreateNewWaveElement(tile, indexPosition);
                    }
                    else
                    {
                        createdWaves[indexPosition.x, indexPosition.y] = waveElementDictionary[tile];
                    }
                }
            }
        }

        for(int i = 0; i < readArea.x; i++)
        {
            for(int j = 0; j < readArea.y; j++)
            {
                Vector2Int indexPosition = new Vector2Int(i, j);
                WaveElement waveElement = createdWaves[indexPosition.x, indexPosition.y];
                if(waveElement != null)
                {
                    waveElement.AddNeighbors(GetNeighbors(indexPosition));
                }
            }
        }
    }

    WaveElement[][] GetNeighbors(Vector2Int indexPosition)
    {
        List<WaveElement>[] neighbors = new List<WaveElement>[4];

        for (int i = 0; i < 4; i++)
        {
            neighbors[i] = new List<WaveElement>();
        }

        for (int i = 0; i < 4; i++)
        {
            Vector2Int newPos = indexPosition + new Vector2Int(directions[i].x, directions[i].y);
            if(CheckMatrixPos(newPos))
            {
                neighbors[i].Add(createdWaves[newPos.x, newPos.y] != null ? 
                createdWaves[newPos.x, newPos.y] : //not null
                createdWaves[indexPosition.x, indexPosition.y]); // null
            }
        }

        WaveElement[][] waveNeighbors = new WaveElement[4][];
        for (int i = 0; i < 4; i++)
        {
            waveNeighbors[i] = neighbors[i].ToArray();
        }

        return waveNeighbors;
    }

    bool CheckMatrixPos(Vector2Int matrixPos)
    {
        return matrixPos.x >= 0 && matrixPos.x < readArea.x && matrixPos.y >= 0 && matrixPos.y < readArea.y;
    }

    void CreateNewWaveElement(Tile tile, Vector2Int indexPosition)
    {
        WaveElement waveElement = new WaveElement(tile);
        createdWaves[indexPosition.x, indexPosition.y] = waveElement;
        waveElementDictionary.Add(tile, waveElement);
    }

    void DebugWaveElements()
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
