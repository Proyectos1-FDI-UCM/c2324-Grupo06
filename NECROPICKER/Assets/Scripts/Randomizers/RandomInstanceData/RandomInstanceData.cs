using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomInstanceData", menuName = "Random", order = 1)]
public class RandomInstanceData : ScriptableObject
{
    [SerializeField] GameObject[] _prefabArray;
    public GameObject[] PrefabArray => _prefabArray;
}
