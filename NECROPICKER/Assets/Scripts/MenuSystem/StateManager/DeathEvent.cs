using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Este script se encarga de gestionar eventos relacionados con la muerte de un personaje u objeto.
//Al despertar (Awake), se suscribe al evento de muerte del gestor global del estado, y al destruirse (OnDestroy),
//se desuscribe del mismo. Cuando se produce la muerte (Death), invoca el evento personalizado onDeath.

public class DeathEvent : MonoBehaviour
{
    [SerializeField] GlobalStateManager globalStateManager;
    [SerializeField] UnityEvent onDeath = new UnityEvent();
    public UnityEvent OnDeath => onDeath;

    private void Awake() => globalStateManager.OnDeath.AddListener(Death);
    private void OnDestroy() => globalStateManager.OnDeath.RemoveListener(Death);

    void Death() => onDeath?.Invoke();
}
