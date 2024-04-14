using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    UnityEvent<float> onHealthChanged = new UnityEvent<float>();
    public UnityEvent<float> OnHealthChanged => onHealthChanged;
    UnityEvent<float> onMaxHealthChanged = new UnityEvent<float>();
    public UnityEvent<float> OnMaxHealthChanged => onMaxHealthChanged;

    UnityEvent<float> onHealthDifer = new UnityEvent<float>();
    public UnityEvent<float> OnHealthDifer => onHealthDifer;

    [SerializeField] UnityEvent onTakeDamage = new UnityEvent();
    public UnityEvent OnTakeDamage => onTakeDamage;

    [SerializeField] UnityEvent onDeath = new UnityEvent();
    public UnityEvent OnDeath => onDeath;

    [SerializeField] float _currentHealth = 1;
    public float currentHealth
    {
        get => _currentHealth;
        set
        {
            float difer = value - _currentHealth;
            OnHealthDifer?.Invoke(difer);

            _currentHealth = value;
            OnHealthChanged?.Invoke(_currentHealth);

            if (value <= 0) Death();
        }
    }

    [SerializeField] public float _maxHealth = 1;
    public float maxHealth
    {
        get => _maxHealth;
        set
        {
            OnMaxHealthChanged?.Invoke(_maxHealth);
        }
    }

    void Start() => SetCurrentHealth(maxHealth);

    public void Death() => onDeath?.Invoke();

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth > 0) OnTakeDamage?.Invoke();
    }

    public void NecroDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void Heal(float healAmount)
    {
        if (healAmount > _maxHealth - currentHealth) 
        {
            currentHealth += _maxHealth - currentHealth;
        }
        else currentHealth += healAmount;
    }
    public void SetMaxHealth(float newMaxHealth)
    {
        _maxHealth = newMaxHealth;
        maxHealth = newMaxHealth;
    }
    public void SetCurrentHealth(float newCurrentHealth) => currentHealth = newCurrentHealth;
    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => _maxHealth;
}