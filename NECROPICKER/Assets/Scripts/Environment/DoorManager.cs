using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    EnemyCounter _myCounter;

    private void Start()
    {

    }
    private void DoorBehaviour(int enemies)
    {
        if (enemies > 0) Open();
        else Close();
    }
    private void Open()
    {
        foreach(Transform child  in transform)
        {
            child.GetComponent<Animator>().SetBool("EnemiesDeployed", false);
        }
    }
    private void Close()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Animator>().SetBool("EnemiesDeployed", true);
        }
    }
}
