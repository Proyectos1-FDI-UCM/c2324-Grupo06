using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    bool active = false; //Sirve para saber si la animacion de low life esta activa o no

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

    [SerializeField] UnityEvent onLowLife = new UnityEvent();
    public UnityEvent OnLowLife => onLowLife;

    [SerializeField] UnityEvent onNormalLife = new UnityEvent();
    public UnityEvent OnNormalLife => onNormalLife;

    [SerializeField] float _currentHealth = 1;
    [SerializeField] float _lowLifeAnimDuration = 3;
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
        LookLowLife();
    }

    public void NecroDamage(float damage)
    {
        currentHealth -= damage;
        LookLowLife();
    }

    public void Heal(float healAmount)
    {
        if (healAmount > _maxHealth - currentHealth) 
        {
            currentHealth += _maxHealth - currentHealth;
        }
        else currentHealth += healAmount;
        LookLowLife();
    }
    public void SetMaxHealth(float newMaxHealth)
    {
        _maxHealth = newMaxHealth;
        maxHealth = newMaxHealth;
    }
   
    public void SetCurrentHealth(float newCurrentHealth) => currentHealth = newCurrentHealth;
    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => _maxHealth;
    private void LookLowLife()
    {
        if (currentHealth <= 4 && currentHealth > 0)
        {
            if (!active)
            {
                onLowLife?.Invoke();
                active = true;
            }
        }
        else if (active)
        {
            onNormalLife?.Invoke();
            active = false;
        }
    }
}