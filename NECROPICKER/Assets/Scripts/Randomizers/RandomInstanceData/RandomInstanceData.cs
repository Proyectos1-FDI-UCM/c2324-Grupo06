using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomInstanceData", menuName = "Random", order = 1)]
public class RandomInstanceData : ScriptableObject
{
    [SerializeField] GameObject[] _prefabArray; //Lista de GameObjects que se asigna en editor 
    public GameObject[] PrefabArray => _prefabArray; //Creacción de una lsita pública de gameObjects que tenga los componentes de la lista de arriba
}
