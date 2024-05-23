using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Comprueba si la probabilidad de un RollProbabilityBehaviour está dentro de un rango determinado.
public class ReadProbabilityCondition : MonoBehaviour, ICondition
{
    [SerializeField] 
    [Range(0,1)] 
    float lowLimit;

    [SerializeField]
    [Range(0,1)] 
    float highLimit;

    RollProbabilityBehaviour _rollProbabilityBehaviour;

    private void Awake() {
        _rollProbabilityBehaviour = GetComponentInParent<RollProbabilityBehaviour>();
    }

    public bool CheckCondition()
    {
        return _rollProbabilityBehaviour.Probability >= lowLimit && _rollProbabilityBehaviour.Probability <= highLimit;
    }

    private void OnValidate() {
        float probability = highLimit - lowLimit;

        if(probability > 0) name = $"Probability {Mathf.Round((highLimit - lowLimit) * 100)}%";
        else name = "VACÍO INCONMENSURABLE";
    }
}
