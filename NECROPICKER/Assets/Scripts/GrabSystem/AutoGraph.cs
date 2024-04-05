using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGraph : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    private void OnTriggerEnter2D(Collider2D _playerCollider)
    {
        if (_gameObject.transform == _playerCollider.transform)
        {

        }
    }
}
