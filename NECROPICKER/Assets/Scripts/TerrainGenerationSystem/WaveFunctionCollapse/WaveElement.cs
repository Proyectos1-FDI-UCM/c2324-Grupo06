using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveElement //Script encargado de genera tiles en función de sus tiles vecinos
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

    void SetNeighbors(WaveElement[][] neighbors) //Método que asigna los vecinos en función de los que tenemos arriba
    {
        for (int i = 0; i < 4; i++) //Recorre para asignar todos los vecinos
        {
            neighbors[i] = neighbors[i].ToHashSet().ToArray();
        }
        this.neighbors = neighbors; //La cantidad de vecinos es la equivalente a la asignada en el recorrido
    }

    public void AddNeighbors(WaveElement[][] neihgborsToAdd) //Método encargado de añadir los vecinos
    {
        WaveElement[][] newNeighbors = new WaveElement[4][]; //Creación de un nuevo WaveElement de tamaño 4

        for (int i = 0; i < 4; i++) //Para cada vecino
        {
            List<WaveElement> newNeighbor = new List<WaveElement>();
            newNeighbor.AddRange(neighbors[i]); //Se añade el rango del waveElement
            newNeighbor.AddRange(neihgborsToAdd[i]);//Se añade el rango del WaveElement del método
            newNeighbors[i] = newNeighbor.ToArray(); //Asigna deicho vecion al array
        }

        SetNeighbors(newNeighbors); //Se asignan los vecinos
    }
}
