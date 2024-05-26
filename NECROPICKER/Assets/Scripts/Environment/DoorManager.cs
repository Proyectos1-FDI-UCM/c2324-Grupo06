using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script gestiona una puerta que se abre y se cierra según el estado de los enemigos.
// Utiliza el EnemyCounter para escuchar eventos cuando se muestran o se derrotan enemigos, y reproduce la animación correspondiente.

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
