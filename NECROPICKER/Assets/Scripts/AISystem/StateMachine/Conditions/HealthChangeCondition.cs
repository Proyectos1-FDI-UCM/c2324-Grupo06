using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChangeCondition : MonoBehaviour, ICondition
{
    HealthHandler healthHandler;
    [SerializeField] Vector2 diferRange;
    float healthDiferValue = 0;

    private void Awake() {
        healthHandler = GetComponentInParent<HealthHandler>();
        healthHandler.OnHealthDifer.AddListener(SetDiferValue);
    }

    public bool CheckCondition()
    {
        float diferValueCopy = healthDiferValue;
        healthDiferValue = 0;
        if(diferValueCopy >= diferRange.x && diferValueCopy <= diferRange.y) print("Health difer value: " + diferValueCopy);
        return diferValueCopy >= diferRange.x && diferValueCopy <= diferRange.y;
    }

    void SetDiferValue(float diferValue)
    {
        healthDiferValue = diferValue;
    }

    private void OnValidate() {
        name = "healthDifer (" + diferRange.x + " - " + diferRange.y + ")";
    }
}
