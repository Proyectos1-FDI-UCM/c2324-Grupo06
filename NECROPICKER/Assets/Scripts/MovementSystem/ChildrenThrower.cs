using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenThrower : MonoBehaviour
{
    float randomDirection;
    float force;
    [SerializeField] float minForce = 10;
    [SerializeField] float maxForce = 20;

    [SerializeField] float minRotforce = -10;
    [SerializeField] float maxRotforce = 10;

    private void Start()
    {
        foreach(Transform child in transform)
        {
            randomDirection = Random.Range(0, 360);
            force = Random.Range(minForce, maxForce);
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();

            rb.AddForce(new Vector2 (Mathf.Sin(randomDirection) * force, Mathf.Cos(randomDirection) * force), ForceMode2D.Impulse);
            rb.AddTorque(Random.Range(minRotforce, maxRotforce), ForceMode2D.Impulse);
        }
    }
}
