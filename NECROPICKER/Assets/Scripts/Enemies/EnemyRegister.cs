using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegister : MonoBehaviour
{
    [SerializeField] EnemyCounter _myCounter;
    HealthHandler _myHealthHandler;
    //añade el objeto actual al EnemyCounter
    private void Start()
    {
        _myHealthHandler = GetComponent<HealthHandler>();
        _myHealthHandler.OnDeath.AddListener(UnregisterEnemy);
        _myCounter.RegisterEnemy();
    }
    private void UnregisterEnemy()
    {
       // _myCounter.UnregisterEnemy();
    }
    private void OnDisable()
    {
        _myHealthHandler.OnDeath.RemoveListener(UnregisterEnemy);
    }
}
