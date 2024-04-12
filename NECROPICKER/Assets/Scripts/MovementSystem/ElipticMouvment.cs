using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElipticMouvment : MonoBehaviour
{
    [SerializeField]    
    private float a, b, x, y, alpha, X, Y;
    [SerializeField]
    private Transform _center;


    private void Update()
    {
        alpha += 10;        
        X = x + (a * Mathf.Cos(alpha * .005f));
        Y = y + (b * Mathf.Sin(alpha * .005f));
        this.gameObject.transform.position = new Vector3(X, 0, Y);
    }
}