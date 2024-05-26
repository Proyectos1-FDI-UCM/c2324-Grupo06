using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;


// Este script es un ScriptableObject que mantiene un contador de enemigos, invocando eventos cuando se muestran enemigos
// y cuando todos los enemigos son derrotados. Proporciona métodos para registrar y eliminar enemigos, así como para reiniciar el contador.

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
        if (_totalEnemies == 0) OnEnemiesDefeated?.Invoke();
    }

    public void ResetCounter()
    {
        _totalEnemies = 0;
        OnEnemiesDefeated?.Invoke();
    }
}
