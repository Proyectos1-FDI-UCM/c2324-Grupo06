using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destruye el objeto que contiene este componente.
public class DestroyBehaviour : MonoBehaviour, IBehaviour
{
    public void ExecuteBehaviour()
    {
       
        Destroy(GetComponentInParent<StateHandler>().transform.parent.gameObject);
    }
    private void OnValidate()
    {
        name = "Destroy this gameobject";
    }
}
