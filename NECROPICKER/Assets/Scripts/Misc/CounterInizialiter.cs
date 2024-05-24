using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInizialiter : MonoBehaviour
{
    [SerializeField] EnemyCounter _counter;
    /// <summary>
    /// inicializa el contador de enemigos a 0
    /// </summary> 
    
    
    private void Awake()
    {
        _counter._totalEnemies = 0;
    }
}
