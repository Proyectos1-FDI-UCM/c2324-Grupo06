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
    //Cuando se ejecuta el comportamiento, se habilita el colider para que afecte a objetos a su alrededor y se hablita el efecto del sprite
    public void ExecuteBehaviour()
    {
        col.enabled = true;
        effect.enabled = true;

        
        //Destroy(Bumberol);
    }
    //Settea el nombre del script a explote Behaviour cada vez que se carga el script o se modifica un valor en el inspector
    private void OnValidate() => name = $"explote Behaviour";
}
