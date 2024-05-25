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
    public WaveElement InitialWave //Constructora
    {
        set 
        { 
            initialWave = value;
        }
    }

    [SerializeField] WaveElement[,] waveMap;
    Vector2Int[] directions = new Vector2Int[] { Vector2Int.up, Vector2Int.left, Vector2Int.right, Vector2Int.down };

    private void OnDrawGizmos() //Cuando se dibujen los gizmos
    {
        grid = GetComponentInParent<Grid>();
        Gizmos.color = Color.green; //Se asigna el color
        Gizmos.DrawWireCube(transform.position + new Vector3(size.x * grid.cellSize.x / 2, size.y * grid.cellSize.y / 2, 0) , new Vector3(size.x * grid.cellSize.x, size.y * grid.cellSize.y, 0)); //Se dibuja en la posición correspondiente con su tamaño definido
    }

    private void Awake() {
        waveMap = new WaveElement[size.x, size.y];
        tilemap = GetComponentInParent<Tilemap>();
        grid = GetComponentInParent<Grid>();
    }

    public void Collapse(WaveElement waveElement) //Método que asigna a initialwave el WaveElement que le pasemos e inicie su corutina
    {
        initialWave = waveElement;
        StartCoroutine(WaveFunction());
    }

    IEnumerator WaveFunction()
    {
        List<Vector2Int> wavesToComplete = new List<Vector2Int>(); //Nos creamos una lista de vectores

        Vector2Int initialPos = new Vector2Int(size.x / 2, size.y / 2); //Guardamos la posición inicial
        SetWaveElement(initialPos, initialWave, wavesToComplete); //Seteamos los elementos del Wave

        while(wavesToComplete.Count > 0) //Mientras que haya Waves sin completar
        {
            List<Vector2Int> newWavesPositions = new List<Vector2Int>(); //Nos creamos otra variable para asignarle las posiciones

            foreach(Vector2Int tilePos in wavesToComplete) //recorremos todos los elementos del wavesToComplet
            {
                WaveElement wave = waveMap[tilePos.x, tilePos.y]; //Nos creamos un WaveElement al que le asignamos la posición del tile del WaveMap
                for(int i = 0; i < 4; i++)
                {
                    Vector2Int newPos = tilePos + directions[i]; //Guardamos la nueva posición
                    if(CheckPosition(newPos)) //Si está dentro Setea el wave element
                    {
                        SetWaveElement(newPos, ProccesWaveElementSet(newPos), newWavesPositions);
                    }
                }
            }
            yield return new WaitForSeconds(0.001f); //Tiempo a esperar
            wavesToComplete = newWavesPositions; //Rellenamos el WaveToComplete
        }
    }

    WaveElement ProccesWaveElementSet(Vector2Int pos)
    {
        List<WaveElement> intersectedWaves = new List<WaveElement>();

        for(int i = 0; i < 4; i++) //Para cada elemento del Wave
        {
            Vector2Int newPos = pos + directions[i]; //Calcula la nueva posición
            WaveElement waveInPos = CheckWave(newPos); //Se asigna a la posición del CheckWave
            if(waveInPos != null) // Si no es null
            {
                //Se comprueba el total de Wavers intersecados y se asigna el intersected wave en función del total de intersecados que halla
                if (intersectedWaves.Count == 0) 
                {
                    intersectedWaves.AddRange(CheckWave(newPos).Neighbors[i]);
                }
                else
                {
                    intersectedWaves = IntersectedWaveElements(intersectedWaves.ToArray(), waveInPos.Neighbors[^i]).ToList();
                }
            }
        }
        if(intersectedWaves.Count == 0) //si el intersected wave es 0
        {
            return initialWave; //Devuelve el valor inicial
        }
        return intersectedWaves[Random.Range(0, intersectedWaves.Count)]; // si es > que 0 devuelve un valor aleatorio del intersectedWave
    }

    WaveElement[] IntersectedWaveElements(WaveElement[] wave1, WaveElement[] wave2) //Método que devuelve la cantidad de elemetos que se encuentren intersecados
    {
        List<WaveElement> intersectedWaves = new List<WaveElement>(); //WaveElement donde almacenaremos los intesecados
        for(int i = 0; i < wave1.Length; i++) //Recorre el primer Wave
        {
            for(int j = 0; j < wave2.Length; j++) //Recorre el segundo Wave
            {
                if(wave1[i] == wave2[j]) //Si coincide
                {
                    intersectedWaves.Add(wave1[i]); //Añadelo al intersected wave
                }
            }
        }
        return intersectedWaves.ToArray(); //Devuelve el intersected Wave como un array
    }

    void SetWaveElement(Vector2Int pos, WaveElement wave, List<Vector2Int> wavesToComplete) //Método que asigna el elemento del Wave en función de una posición y un vector que le pasemos
    {
        waveMap[pos.x, pos.y] = wave;
        tilemap.SetTile(tilemap.WorldToCell(new Vector3Int((int)transform.position.x, (int)transform.position.y, 0) 
        + new Vector3Int(pos.x * (int)grid.cellSize.x, pos.y * (int)grid.cellSize.x, 0)), wave.Tile);
        wavesToComplete.Add(pos);
    }

    bool CheckPosition(Vector2Int pos) //Método que comprueba si la posición entra dentro del rango o no
    {
        if (pos.x < 0 || pos.x >= size.x || pos.y < 0 || pos.y >= size.y || waveMap[pos.x, pos.y] != null)
        {
            return false;
        }
        return true;
    }

    WaveElement CheckWave(Vector2Int pos) //Método que comprueba si el wave está en rango o no
    {
        if (pos.x < 0 || pos.x >= size.x || pos.y < 0 || pos.y >= size.y)
        {
            return null;
        }
        return waveMap[pos.x, pos.y]; //Si está en rango devuelve el wavMap en la posición correspondiente
    }

    Vector2Int RandomDirection() //Método que genera una dirección aleatoria
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