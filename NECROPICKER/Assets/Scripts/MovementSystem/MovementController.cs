using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float _speed = 10f;
    private float _OriginalSpeed;
    public float speed => _speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _OriginalSpeed = _speed;
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    public void MoveTowards(Vector2 target, float multiplier)
    {
        Vector2 direction = target - (Vector2)transform.position;
        Move(direction.normalized * multiplier);
    }
    private void Update()
    {
        Move(rb.velocity.normalized);
    }
    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
    public void ReturnOriginalSpeed()
    {
        _speed = _OriginalSpeed;
    }
}
