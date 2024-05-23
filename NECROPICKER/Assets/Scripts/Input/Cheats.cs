using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Cheats : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Inventory _health;
    [SerializeField] private int _healthSetted;
    [SerializeField] private int _maxHealthSetted;
    [SerializeField] private int _healthToHeal;
    [SerializeField] private ItemData[] _objectsToInstantiate = new ItemData[10];
    [SerializeField] private int[] _objectsToAdd = new int[10];
    [SerializeField] private ItemData _potion;
    [SerializeField] private int _potionsToAdd;
    HealthHandler _myHealthHandler;
    LowLifeController _lowLifeController;

    private void Start()
    {
        _myHealthHandler = GetComponent<HealthHandler>();
        _lowLifeController = GetComponent<LowLifeController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) //Setear vida actual
        {
            _myHealthHandler.SetCurrentHealth(_healthSetted);
        }
        if (Input.GetKeyDown(KeyCode.H)) //Curar la cantidad de vida asignada
        {
            _myHealthHandler.Heal(_healthToHeal);
        }
        if (Input.GetKeyDown(KeyCode.K)) //Llamar al método de muerte
        {
            _myHealthHandler.Death();
        }
        if (Input.GetKeyDown(KeyCode.M)) //Setear vida máxima
        {
            _myHealthHandler.SetMaxHealth(_maxHealthSetted);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0)) //Instanciar objetos
        {
            AddItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) //Instanciar objetos
        {
            AddItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) //Instanciar objetos
        {
            AddItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) //Instanciar objetos
        {
            AddItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4)) //Instanciar objetos
        {
            AddItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5)) //Instanciar objetos
        {
            AddItem(5);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6)) //Instanciar objetos
        {
            AddItem(6);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7)) //Instanciar objetos
        {
            AddItem(7);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8)) //Instanciar objetos
        {
            AddItem(8);
        }
        if (Input.GetKeyDown(KeyCode.Keypad9)) //Instanciar objetos
        {
            AddItem(9);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            for(int i = 0; i < _potionsToAdd; i++)
            {
                _health.AddItem(_potion);
            }
        }
    }
    private void AddItem(int n)
    {
        if (_objectsToInstantiate[n] != null) //Si hay objeto para añadir
        {
            for (int j = 0; j < _objectsToAdd[n]; j++) //Añade un objeto hasta que llegues al límite
            {
                _inventory.AddItem(_objectsToInstantiate[n]);
            }
        }
    }
}
