using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstance : MonoBehaviour
{
    [SerializeField] RandomInstanceData _randomInstanceData; 
    private void Start() => GenerateRandomInstance();
    void GenerateRandomInstance()
    {
        int randomIndex = Random.Range(0, _randomInstanceData.PrefabArray.Length); //randomIndex = un n�mero aleatorio entre e, 0 - Array de RandomInstance
        GameObject instance = _randomInstanceData.PrefabArray[randomIndex]; //instance = Array de RandomInstance hasya el tama�o del randomIndex
        if (instance != null) Instantiate(instance, transform.position, Quaternion.identity, transform.parent); //Si instance no es null Instancia instance
    }
}
