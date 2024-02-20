using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Counter")]
public class EnemyCounter : ScriptableObject
{
    public int _totalEnemies;

    public UnityEvent OnEnemiesDisplayed = new UnityEvent();
    public UnityEvent OnEnemiesDefeated = new UnityEvent();

    public void RegisterEnemy()
    {
        _totalEnemies++;
        if(_totalEnemies == 1) OnEnemiesDisplayed?.Invoke();
    }
    public void UnregisterEnemy()
    {
        _totalEnemies--;
        if(_totalEnemies == 0) OnEnemiesDefeated?.Invoke();
    }
}
