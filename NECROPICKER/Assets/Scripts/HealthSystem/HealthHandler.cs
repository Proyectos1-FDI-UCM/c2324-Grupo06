using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    UnityEvent<float> onHealthChanged = new UnityEvent<float>();
    public UnityEvent<float> OnHealthChanged => onHealthChanged;

    UnityEvent<float> onHealthDifer = new UnityEvent<float>();
    public UnityEvent<float> OnHealthDifer => onHealthDifer;

    [SerializeField] UnityEvent onTakeDamage = new UnityEvent();
    public UnityEvent OnTakeDamage => onTakeDamage;

    [SerializeField] UnityEvent onDeath = new UnityEvent();
    public UnityEvent OnDeath => onDeath;

    float _currentHealth = 1;
    public float currentHealth
    {
        get => _currentHealth;
        set
        {
            float difer = value - _currentHealth;
            OnHealthDifer?.Invoke(difer);

            if (value < _currentHealth) OnTakeDamage?.Invoke();

            _currentHealth = value;
            OnHealthChanged?.Invoke(_currentHealth);

            if (value <= 0) 
            {
                OnDeath?.Invoke();
               
            }
        }
    }

    [SerializeField] float maxHealth;

    void Start() => SetCurrentHealth(maxHealth);
    public void TakeDamage(float damage) => currentHealth -= damage;
    public void Heal(float healAmount) => currentHealth += healAmount;
    public void SetMaxHealth(float newMaxHealth) => maxHealth = newMaxHealth;
    public void SetCurrentHealth(float newCurrentHealth) => currentHealth = newCurrentHealth;
}