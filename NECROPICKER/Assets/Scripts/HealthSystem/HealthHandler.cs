using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    UnityEvent<float> onHealthChanged = new UnityEvent<float>(); //Evento que se llama cuando la vida cambie
    public UnityEvent<float> OnHealthChanged => onHealthChanged; 
    UnityEvent<float> onMaxHealthChanged = new UnityEvent<float>(); //Evento que se llama cuando la vida máxima cambie
    public UnityEvent<float> OnMaxHealthChanged => onMaxHealthChanged;

    UnityEvent<float> onHealthDifer = new UnityEvent<float>(); //Evento que se llama cuando la vida actual difiere del currentHealth
    public UnityEvent<float> OnHealthDifer => onHealthDifer;
     
    [SerializeField] UnityEvent onTakeDamage = new UnityEvent(); //Evento que se llama cuando se recive daño
    public UnityEvent OnTakeDamage => onTakeDamage;

    [SerializeField] UnityEvent onDeath = new UnityEvent(); //Evento que se llama cuando la entidad muere
    public UnityEvent OnDeath => onDeath;

    [SerializeField] UnityEvent onLowLife = new UnityEvent(); //Evento que se llama cuando la vida del jugador este en estado crítico
    public UnityEvent OnLowLife => onLowLife;

    [SerializeField] UnityEvent onNormalLife = new UnityEvent(); //Evento que se llama cuando la vida del jugador no este en estado crítico
    public UnityEvent OnNormalLife => onNormalLife;

    [SerializeField] public float _maxHealth = 1;//Variable que representa la vida máxima
    [SerializeField] float _currentHealth = 1; //Variable que representa la vida actual 
    [SerializeField] float _lowLifeAnimDuration = 3; //Variable que indica el tiempo que dura la animación de poca vida
    bool active = false; //Sirve para saber si la animacion de low life esta activa o no
    public float currentHealth
    {
        get => _currentHealth; //Obtiene la vida actual 
        set
        {
            float difer = value - _currentHealth; //Calcula la nueva vida 
            OnHealthDifer?.Invoke(difer); //LLamada al evento para comprobar el valor de difer con currenthealth

            _currentHealth = value; //Iguala la cantidad de vida actual al valor que está debe tener
            OnHealthChanged?.Invoke(_currentHealth); //LLamada al evento de cambio de vida

            if (value <= 0) Death(); //Si el valor de la vida es = o menor a 0 llamada al método muerte
        }
    }
    public float maxHealth
    {
        get => _maxHealth;//Obtiene la vida máxima
        set
        {
            OnMaxHealthChanged?.Invoke(_maxHealth); //LLamada al evento de cambio de vida máxima
        }
    }

    void Start() => SetCurrentHealth(maxHealth); //Al inicio se setea la vida actual a la máxima
    public void Death() => onDeath?.Invoke(); //LLamada al evento de muerte

    public void TakeDamage(float damage) //método que se llama cada vez que se recive daño
    {
        currentHealth -= damage; // Cambia la vida actual en función del daño que recive
        if(currentHealth > 0) OnTakeDamage?.Invoke(); //Llamada al evento de recivir daño siempre y cuando la vida sea > 0
        LookLowLife(); //Llamada al método para comprobar la vida del jugador
    }

    public void NecroDamage(float damage) //método que se llama cuando el necronomicon daña al jugador
    {
        currentHealth -= damage; //Cambia la vida actual en función del daño que recive
        LookLowLife(); //Llamada al método para comprobar la vida del jugador
    }

    public void Heal(float healAmount) //Método para curarse
    {
        if (healAmount > _maxHealth - currentHealth) //Si la cantidad de vida es mayor que la vida máxima - la actual
        {
            currentHealth += _maxHealth - currentHealth; //La vida actual será la vida actual + la máxima - la actual
        }
        else currentHealth += healAmount; //Si no la vida actual es la actual + la cantidad curada
        LookLowLife(); //Llamada al método para comprobar la vida del jugador
    }
    public void SetMaxHealth(float newMaxHealth) //Setea la vida máxima 
    {
        //Se setean ambas variables de maxhealth a la nueva vida máxima
        _maxHealth = newMaxHealth;
        maxHealth = newMaxHealth;
    }
   
    public void SetCurrentHealth(float newCurrentHealth) => currentHealth = newCurrentHealth; //Setea la vida actual 
    public float GetCurrentHealth() => currentHealth; //Obtiene la vida actual 
    public float GetMaxHealth() => _maxHealth; //Obtiene la vida máxima 
    private void LookLowLife() //Método que observa la vida del jugador y comprueba si está en estado grave o no
    {
        if (currentHealth <= 4 && currentHealth > 0) //Si entra en estado crítico
        {
            if (!active) //Si no se encuentra activa ya
            {
                onLowLife?.Invoke(); //Llamada al evento de vida baja
                active = true; //Se cambia el valor del booleano
            }
        }
        else if (active) //Si está activa y no tiene la vida baja
        {
            onNormalLife?.Invoke(); //Llamada al evento de vida normal
            active = false; //Se cambia el valor del booleano
        }
    }
}