using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Explotebehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField ]Collider2D col;
    [SerializeField] GameObject Bumberol;
    [SerializeField] SpriteRenderer effect;
    
    private void Start()
    {
        col = GetComponent<Collider2D>();
        
    }
    public void ExecuteBehaviour()
    {
        UnityEngine.Debug.Log("Explotaaaaaaaaaaaa mondongo");
        col.enabled = true;
        effect.enabled = true;

        
        //Destroy(Bumberol);
    }
    private void OnValidate() => name = $"explote Behaviour";
}
