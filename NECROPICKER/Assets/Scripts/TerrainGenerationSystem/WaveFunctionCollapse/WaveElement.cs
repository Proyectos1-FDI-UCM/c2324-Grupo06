using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveElement //Script encargado de genera tiles en funci�n de sus tiles vecinos
{
    [SerializeField] Tile tile;
    public Tile Tile { get { return tile; } }
    [SerializeField] WaveElement[][] neighbors = new WaveElement[4][];
    public WaveElement[][] Neighbors { get { return neighbors; } }

    public WaveElement(Tile tile) //Constructora
    {
        this.tile = tile; //Asignamos el tile
        neighbors = new WaveElement[4][]; //Asignamos los vecinos

        for (int i = 0; i < 4; i++) //Seteamos los vecinos para que no sean null
        {
            neighbors[i] = new WaveElement[0];
        }
    }

    void SetNeighbors(WaveElement[][] neighbors) //M�todo que asigna los vecinos en funci�n de los que tenemos arriba
    {
        for (int i = 0; i < 4; i++) //Recorre para asignar todos los vecinos
        {
            neighbors[i] = neighbors[i].ToHashSet().ToArray();
        }
        this.neighbors = neighbors; //La cantidad de vecinos es la equivalente a la asignada en el recorrido
    }

    public void AddNeighbors(WaveElement[][] neihgborsToAdd) //M�todo encargado de a�adir los vecinos
    {
        WaveElement[][] newNeighbors = new WaveElement[4][]; //Creaci�n de un nuevo WaveElement de tama�o 4

        for (int i = 0; i < 4; i++) //Para cada vecino
        {
            List<WaveElement> newNeighbor = new List<WaveElement>();
            newNeighbor.AddRange(neighbors[i]); //Se a�ade el rango del waveElement
            newNeighbor.AddRange(neihgborsToAdd[i]);//Se a�ade el rango del WaveElement del m�todo
            newNeighbors[i] = newNeighbor.ToArray(); //Asigna deicho vecion al array
        }

        SetNeighbors(newNeighbors); //Se asignan los vecinos
    }
}
