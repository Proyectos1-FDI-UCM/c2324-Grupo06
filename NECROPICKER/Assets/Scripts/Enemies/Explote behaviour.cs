using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Explotebehaviour : MonoBehaviour, IBehaviour
{
    
    void Awake()
    {
       
    }
    public void ExecuteBehaviour()
    {
        

    }
    private void OnValidate() => name = $"explote Behaviour";
}
