using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlayer : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] float X = 0.0f;
    [SerializeField] float Y = 0.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out InputManager _input))
        {
            _playerTransform.position = new Vector3(X, Y, 0);
        }
    }
}
