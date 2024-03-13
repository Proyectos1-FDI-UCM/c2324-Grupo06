using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenThrower : MonoBehaviour
{
    float randomDirection;
    float force;
    [SerializeField] float minForce = 10;
    [SerializeField] float maxForce = 20;

    private void Start()
    {
        foreach(Transform child in transform)
        {
            randomDirection = Random.Range(0, 360);
            force = Random.Range(minForce, maxForce);
            child.GetComponent<Rigidbody2D>().AddForce(new Vector2 (Mathf.Sin(randomDirection) * force, Mathf.Cos(randomDirection) * force), ForceMode2D.Impulse);
        }
    }
}
