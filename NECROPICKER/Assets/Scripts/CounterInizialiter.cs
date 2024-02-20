using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInizialiter : MonoBehaviour
{
    [SerializeField] EnemyCounter _counter;
    private void Awake()
    {
        _counter._totalEnemies = 0;
    }
}
