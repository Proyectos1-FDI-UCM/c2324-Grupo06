using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;

    ///Activa el objeto al entrar en el área
    private void OnTriggerEnter2D(Collider2D PlayerCollider)
    {
        if(PlayerCollider != null)
        {
            _gameObject.SetActive(true);
        }
    }
}
