using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Cheats : MonoBehaviour
{
    HealthHandler _myHealthHandler;

    [SerializeField] private int _HealthSetted;
    [SerializeField] private int _HealthToHeal;
    [SerializeField] private GameObject[] _objectsToInstantiate = new GameObject[10];
    [SerializeField] private int _quantityToInstantiate;
    private void Start()
    {
        _myHealthHandler = GetComponent<HealthHandler>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) //Curarse
        {
            _myHealthHandler.Heal(_HealthToHeal);
        }
        if (Input.GetKeyDown(KeyCode.M)) //Setear vida máxima
        {
            _myHealthHandler.SetMaxHealth(_HealthSetted);
        }
        if (Input.GetKeyDown(KeyCode.C)) //Instanciar objetos
        {
            for(int i = 0; i < _objectsToInstantiate.Length; i++)
            {
                if (_objectsToInstantiate[i] != null)
                {
                    for(int j = 0; i < _quantityToInstantiate;  j++)
                    {
                        Instantiate(_objectsToInstantiate[i], transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
