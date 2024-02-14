using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstance : MonoBehaviour
{
    [SerializeField] RandomInstanceData _randomInstanceData;

    private void Start() => GenerateRandomInstance();

    void GenerateRandomInstance()
    {
        int randomIndex = Random.Range(0, _randomInstanceData.PrefabArray.Length);
        GameObject instance = _randomInstanceData.PrefabArray[randomIndex];
        if(instance != null) Instantiate(instance, transform.position, Quaternion.identity, transform.parent);
    }
}
