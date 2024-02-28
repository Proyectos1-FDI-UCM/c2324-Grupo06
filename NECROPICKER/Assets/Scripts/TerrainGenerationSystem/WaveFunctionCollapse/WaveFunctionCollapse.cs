using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveFunctionCollapse : MonoBehaviour
{
    Tilemap tilemap;
    Grid grid;
    [SerializeField] Vector2Int size;

    [SerializeField] WaveElement initialWave;
    public WaveElement InitialWave
    {
        set 
        { 
            initialWave = value;
        }
    }

    [SerializeField] WaveElement[,] waveMap;
    Vector2Int[] directions = new Vector2Int[] { Vector2Int.up, Vector2Int.left, Vector2Int.right, Vector2Int.down };

    private void OnDrawGizmos()
    {
        grid = GetComponentInParent<Grid>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + new Vector3(size.x * grid.cellSize.x / 2, size.y * grid.cellSize.y / 2, 0) , new Vector3(size.x * grid.cellSize.x, size.y * grid.cellSize.y, 0));
    }

    private void Awake() {
        waveMap = new WaveElement[size.x, size.y];
        tilemap = GetComponentInParent<Tilemap>();
        grid = GetComponentInParent<Grid>();
    }

    public void Collapse(WaveElement waveElement)
    {
        initialWave = waveElement;
        StartCoroutine(WaveFunction());
    }

    IEnumerator WaveFunction()
    {
        List<Vector2Int> wavesToComplete = new List<Vector2Int>();

        Vector2Int initialPos = new Vector2Int(size.x / 2, size.y / 2);
        SetWaveElement(initialPos, initialWave, wavesToComplete);

        while(wavesToComplete.Count > 0)
        {
            List<Vector2Int> newWavesPositions = new List<Vector2Int>();

            foreach(Vector2Int tilePos in wavesToComplete)
            {
                WaveElement wave = waveMap[tilePos.x, tilePos.y];
                for(int i = 0; i < 4; i++)
                {
                    Vector2Int newPos = tilePos + directions[i];
                    if(CheckPosition(newPos))
                    {
                        SetWaveElement(newPos, ProccesWaveElementSet(newPos), newWavesPositions);
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
            wavesToComplete = newWavesPositions;
        }
    }

    WaveElement ProccesWaveElementSet(Vector2Int pos)
    {
        List<WaveElement> intersectedWaves = new List<WaveElement>();

        for(int i = 0; i < 4; i++)
        {
            Vector2Int newPos = pos + directions[i];
            WaveElement waveInPos = CheckWave(newPos);
            if(waveInPos != null)
            {
                if(intersectedWaves.Count == 0)
                {
                    intersectedWaves.AddRange(CheckWave(newPos).Neighbors[i]);
                }
                else
                {
                    intersectedWaves = IntersectedWaveElements(intersectedWaves.ToArray(), waveInPos.Neighbors[^i]).ToList();
                }
            }
        }
        if(intersectedWaves.Count == 0)
        {
            return initialWave;
        }
        return intersectedWaves[Random.Range(0, intersectedWaves.Count)];
    }

    WaveElement[] IntersectedWaveElements(WaveElement[] wave1, WaveElement[] wave2)
    {
        List<WaveElement> intersectedWaves = new List<WaveElement>();
        for(int i = 0; i < wave1.Length; i++)
        {
            for(int j = 0; j < wave2.Length; j++)
            {
                if(wave1[i] == wave2[j])
                {
                    intersectedWaves.Add(wave1[i]);
                }
            }
        }
        return intersectedWaves.ToArray();
    }

    void SetWaveElement(Vector2Int pos, WaveElement wave, List<Vector2Int> wavesToComplete)
    {
        waveMap[pos.x, pos.y] = wave;
        tilemap.SetTile(tilemap.WorldToCell(new Vector3Int((int)transform.position.x, (int)transform.position.y, 0) 
        + new Vector3Int(pos.x * (int)grid.cellSize.x, pos.y * (int)grid.cellSize.x, 0)), wave.Tile);
        wavesToComplete.Add(pos);
    }

    bool CheckPosition(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x >= size.x || pos.y < 0 || pos.y >= size.y || waveMap[pos.x, pos.y] != null)
        {
            return false;
        }
        return true;
    }

    WaveElement CheckWave(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x >= size.x || pos.y < 0 || pos.y >= size.y)
        {
            return null;
        }
        return waveMap[pos.x, pos.y];
    }

    Vector2Int RandomDirection()
    {
        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0:
                return Vector2Int.up;
            case 1:
                return Vector2Int.down;
            case 2:
                return Vector2Int.left;
            case 3:
                return Vector2Int.right;
        }
        return Vector2Int.zero;
    }
}