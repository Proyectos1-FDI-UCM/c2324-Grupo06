using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveElement
{
    [SerializeField] Tile tile;
    public Tile Tile { get { return tile; } }
    [SerializeField] WaveElement[][] neighbors = new WaveElement[4][];
    public WaveElement[][] Neighbors { get { return neighbors; } }

    public WaveElement(Tile tile)
    {
        this.tile = tile;
        neighbors = new WaveElement[4][];

        for (int i = 0; i < 4; i++)
        {
            neighbors[i] = new WaveElement[0];
        }
    }

    void SetNeighbors(WaveElement[][] neighbors)
    {
        for (int i = 0; i < 4; i++)
        {
            neighbors[i] = neighbors[i].ToHashSet().ToArray();
        }
        this.neighbors = neighbors;
    }

    public void AddNeighbors(WaveElement[][] neihgborsToAdd)
    {
        WaveElement[][] newNeighbors = new WaveElement[4][];

        for (int i = 0; i < 4; i++)
        {
            List<WaveElement> newNeighbor = new List<WaveElement>();
            newNeighbor.AddRange(neighbors[i]);
            newNeighbor.AddRange(neihgborsToAdd[i]);
            newNeighbors[i] = newNeighbor.ToArray();
        }

        SetNeighbors(newNeighbors);
    }
}
