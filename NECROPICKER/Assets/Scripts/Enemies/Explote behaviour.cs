using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Explotebehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField ]Collider2D collider2D;
    private void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }
    public void ExecuteBehaviour()
    {
        UnityEngine.Debug.Log("Explotaaaaaaaaaaaa mondongo");
        collider2D.enabled = true;
        

    }
    private void OnValidate() => name = $"explote Behaviour";
}
