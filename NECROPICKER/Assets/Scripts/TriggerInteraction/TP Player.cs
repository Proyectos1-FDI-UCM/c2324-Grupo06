using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlayer : MonoBehaviour
{
    [SerializeField] private Transform _vector;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out InputManager _input))
        {
            collision.transform.position = _vector.position.normalized;
        }
    }
}
