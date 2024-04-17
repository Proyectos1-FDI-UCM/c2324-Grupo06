using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] EnemyCounter _myCounter;

    private void Start()
    {
        _myCounter.OnEnemiesDisplayed.AddListener(Close);
        _myCounter.OnEnemiesDefeated.AddListener(Open);
    }
    private void Open()
    {
        GetComponent<Animator>().Play("Open");
    }
    private void Close()
    {
        GetComponent<Animator>().Play("Close");
    }
}
