using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script lanza a los hijos del objeto con una fuerza y un torque aleatorios cuando se habilita, 
// restaurando sus posiciones y rotaciones iniciales cada vez que se reinicia.
public class ChildrenThrower : MonoBehaviour
{
    float randomDirection;
    float force;
    [SerializeField] float minForce = 10;
    [SerializeField] float maxForce = 20;

    [SerializeField] float minRotforce = -10;
    [SerializeField] float maxRotforce = 10;

    Vector2[] initialPositions;
    Quaternion[] initialRotations;

    private void Awake() {
        initialPositions = new Vector2[transform.childCount];
        initialRotations = new Quaternion[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            initialPositions[i] = transform.GetChild(i).position;
            initialRotations[i] = transform.GetChild(i).rotation;
        }
    }

    private void OnEnable() {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position = initialPositions[i];
            transform.GetChild(i).rotation = initialRotations[i];
        }

        Throw();
    }

    void Throw()
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
