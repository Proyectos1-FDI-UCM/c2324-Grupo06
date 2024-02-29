using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Cheats : MonoBehaviour
{
    HealthHandler _myHealthHandler;

    [SerializeField] private int _healthSetted;
    [SerializeField] private int _maxHealthSetted;
    [SerializeField] private int _healthToHeal;
    [SerializeField] private GameObject[] _objectsToInstantiate = new GameObject[10];

    private bool _inmunePressed = false;
    private void Start()
    {
        _myHealthHandler = GetComponent<HealthHandler>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) //Setear vida actual
        {
            _myHealthHandler.SetCurrentHealth(_healthSetted);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            _myHealthHandler.Heal(_healthToHeal);
        }
        if (Input.GetKeyDown(KeyCode.M)) //Setear vida máxima
        {
            _myHealthHandler.SetMaxHealth(_maxHealthSetted);
        }
        if (Input.GetKeyDown(KeyCode.C)) //Instanciar objetos
        {
            for(int i = 0; i < _objectsToInstantiate.Length; i++)
            {
                if (_objectsToInstantiate[i] != null)
                {
                    Instantiate(_objectsToInstantiate[i], transform.position, Quaternion.identity);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_inmunePressed)
            {
                _myHealthHandler.SetInmune(true); 
                _inmunePressed = true;
            }
            else _myHealthHandler.SetInmune(false); _inmunePressed = false;
        }

    }
}
