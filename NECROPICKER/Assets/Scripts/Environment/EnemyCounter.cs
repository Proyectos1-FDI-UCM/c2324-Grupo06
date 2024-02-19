using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    //List<GameObject> enemies = new List<GameObject>();

    private int _totalEnemies = 0;
    public int TotalEnemies { get { return _totalEnemies; } }

    public UnityEvent<int> OnEnemyNumberChanged = new UnityEvent<int>();

    /*private void Start()
    {
        foreach(RandomInstance instance in transform)
        {
            if (instance.TryGetComponent(out HealthHandler enemyHealth)) enemies.Add(instance.gameObject);
        }
        
        _totalEnemies = enemies.ToArray().Length;
    }*/
    public void RegisterEnemy()
    {
        _totalEnemies++;
        OnEnemyNumberChanged?.Invoke(_totalEnemies);
    }
    public void UnregisterEnemy()
    {
        _totalEnemies--;
        OnEnemyNumberChanged?.Invoke(_totalEnemies);
    }
}
