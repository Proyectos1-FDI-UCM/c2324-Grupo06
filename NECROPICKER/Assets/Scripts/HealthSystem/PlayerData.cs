using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _potion;
    private void Start()
    {
        _potion = transform;
        _playerTransform = FindAnyObjectByType<InputManager>().transform;
        _potion.position = _playerTransform.position;
        _potion.rotation = _playerTransform.rotation;
    }
}
