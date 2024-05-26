using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSeter : MonoBehaviour
{
    Tilemap tilemap;
    Grid grid;
    [SerializeField] Vector2Int size;
    [SerializeField] Tile replacementTile;
    [Range(0, 1)]
    [SerializeField] float probability;

    private void OnDrawGizmos() //Método que se llama cuando se dibujan los Gizmos
    {
        Gizmos.color = Color.red; //Cambia el color a rojo
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, size.y, 0)); //Dibuja el gizmos
    }

    private void Awake()
    {
        tilemap = GetComponentInParent<Tilemap>();
        grid = GetComponentInParent<Grid>();
    }

    public void SetTiles() //Método encargado de setear lso tiles en función del tamaño
    {
        Vector3 initialPosition = transform.position - new Vector3(size.x * grid.cellSize.x / 2, size.y * grid.cellSize.y / 2, 0); //Tomamos la posición incial
        for (int i = 0; i < size.x; i++) //Recorrido del eje X
        {
            for (int j = 0; j < size.y; j++) //Recorrido del eje Y 
            {
                Vector3 tilePos = initialPosition + new Vector3(i * grid.cellSize.x, j * grid.cellSize.y, 0); //Tomamos la posición del tile
                Vector3Int fixedTilePos = tilemap.WorldToCell(tilePos); //Corregimos la posición
                tilemap.SetTile(fixedTilePos, replacementTile); //Seteamos el Tile
            }
        }
    }
}