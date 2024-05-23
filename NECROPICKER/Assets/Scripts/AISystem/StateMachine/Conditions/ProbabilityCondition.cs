using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Condición que se cumple con una probabilidad determinada.
public class ProbabilityCondition : MonoBehaviour, ICondition
{
    [Range(0, 100)]
    [SerializeField] float probability;
    public bool CheckCondition()
    {
        return Random.Range(0, 100) < probability;
    }
    private void OnValidate() => gameObject.name = $"Probability {probability}%";
    public void SetProbability(float newProbability) => probability = newProbability;
}