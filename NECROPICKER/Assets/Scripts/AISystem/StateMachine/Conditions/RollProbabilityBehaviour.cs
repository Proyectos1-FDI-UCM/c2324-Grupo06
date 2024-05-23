using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Similar a un dado, cada vez que se ejecuta el comportamiento genera un número aleatorio entre 0 y 1.
public class RollProbabilityBehaviour : MonoBehaviour, IBehaviour
{
    float _probability;
    public float Probability => _probability;

    public void SetProbability(float probability) => _probability = probability;
    public void RollProbability() => _probability = Random.Range(0f, 1f);

    public void ExecuteBehaviour() => RollProbability();
}
