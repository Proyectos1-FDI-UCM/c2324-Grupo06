using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollProbabilityBehaviour : MonoBehaviour, IBehaviour
{
    float _probability;
    public float Probability => _probability;

    public void SetProbability(float probability) => _probability = probability;
    public void RollProbability() => _probability = Random.Range(0f, 1f);

    public void ExecuteBehaviour() => RollProbability();
}
