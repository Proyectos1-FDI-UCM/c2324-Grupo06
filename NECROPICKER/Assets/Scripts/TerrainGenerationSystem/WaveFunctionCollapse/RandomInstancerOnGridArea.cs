using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomInstancerOnGridArea : MonoBehaviour
{
    Tilemap tilemap;
    Grid grid;
    [SerializeField] Vector2Int size;
    [SerializeField] InstanceWithProbability[] instances;

    private void OnDrawGizmos()
    {
        grid = GetComponentInParent<Grid>();
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, 
        new Vector3(size.x * grid.cellSize.x, size.y * grid.cellSize.y, 0));
    }

    private void Awake()
    {
        tilemap = GetComponentInParent<Tilemap>();
        grid = GetComponentInParent<Grid>();
        InstanceRandom();
    }
    void InstanceRandom()
    {
        foreach(InstanceWithProbability instance in instances)
        {
            if(Random.value < instance.Probability)
            {
                for(int i = 0; i < instance.Amount; i++)
                {
                    Vector3 randomOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
                    Vector3 randomPosition = transform.position + randomOffset;

                    // while(Physics2D.OverlapBox(randomPosition, new Vector2(0.5f, 0.5f), 0) != null)
                    // {
                    //     randomOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
                    //     randomPosition = transform.position + randomOffset;
                    // }

                    Instantiate(instance.Prefab, randomPosition, Quaternion.identity);
                }
            }
        }
    }
}

[System.Serializable]
struct InstanceWithProbability
{
    [SerializeField] GameObject prefab;
    public GameObject Prefab => prefab;

    [Range(0, 1)]
    [SerializeField] float probability;
    public float Probability => probability;

    [SerializeField] int amount;
    public int Amount => amount;

    public InstanceWithProbability(GameObject prefab, float probability, int amount)
    {
        this.prefab = prefab;
        this.probability = probability;
        this.amount = amount;
    }
}