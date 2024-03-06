using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InstantiateBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] GameObject prefab;

    public void ExecuteBehaviour()
    {
        Instantiate(prefab, transform.position, quaternion.identity);
    }

    private void OnValidate()
    {
        if(prefab != null)
            name = $"Instantiate {prefab.name}";
    }
}