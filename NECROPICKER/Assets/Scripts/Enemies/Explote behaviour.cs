using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Explotebehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField ]Collider2D col;
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    public void ExecuteBehaviour()
    {
        UnityEngine.Debug.Log("Explotaaaaaaaaaaaa mondongo");
        col.enabled = true;
    }
    private void OnValidate() => name = $"explote Behaviour";
}
