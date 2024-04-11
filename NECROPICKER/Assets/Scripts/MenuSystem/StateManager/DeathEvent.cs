using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathEvent : MonoBehaviour
{
    [SerializeField] GlobalStateManager globalStateManager;
    [SerializeField] UnityEvent onDeath = new UnityEvent();
    public UnityEvent OnDeath => onDeath;

    private void Awake() => globalStateManager.OnDeath.AddListener(Death);
    private void OnDestroy() => globalStateManager.OnDeath.RemoveListener(Death);

    void Death() => onDeath?.Invoke();
}
