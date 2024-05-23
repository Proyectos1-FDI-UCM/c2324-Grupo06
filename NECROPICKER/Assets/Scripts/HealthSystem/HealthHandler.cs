using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    UnityEvent<float> onHealthChanged = new UnityEvent<float>(); //Evento que se llama cuando la vida cambie
    public UnityEvent<float> OnHealthChanged => onHealthChanged; 
    UnityEvent<float> onMaxHealthChanged = new UnityEvent<float>(); //Evento que se llama cuando la vida m�xima cambie
    public UnityEvent<float> OnMaxHealthChanged => onMaxHealthChanged;

    UnityEvent<float> onHealthDifer = new UnityEvent<float>(); //Evento que se llama cuando la vida actual difiere del currentHealth
    public UnityEvent<float> OnHealthDifer => onHealthDifer;
     
    [SerializeField] UnityEvent onTakeDamage = new UnityEvent(); //Evento que se llama cuando se recive da�o
    public UnityEvent OnTakeDamage => onTakeDamage;

    [SerializeField] UnityEvent onDeath = new UnityEvent(); //Evento que se llama cuando la entidad muere
    public UnityEvent OnDeath => onDeath;

    [SerializeField] UnityEvent onLowLife = new UnityEvent(); //Evento que se llama cuando la vida del jugador este en estado cr�tico
    public UnityEvent OnLowLife => onLowLife;

    [SerializeField] UnityEvent onNormalLife = new UnityEvent(); //Evento que se llama cuando la vida del jugador no este en estado cr�tico
    public UnityEvent OnNormalLife => onNormalLife;

    [SerializeField] public float _maxHealth = 1;//Variable que representa la vida m�xima
    [SerializeField] float _currentHealth = 1; //Variable que representa la vida actual 
    [SerializeField] float _lowLifeAnimDuration = 3; //Variable que indica el tiempo que dura la animaci�n de poca vida
    bool active = false; //Sirve para saber si la animacion de low life esta activa o no
    public float currentHealth
    {
        get => _currentHealth; //Obtiene la vida actual 
        set
        {
            float difer = value - _currentHealth; //Calcula la nueva vida 
            OnHealthDifer?.Invoke(difer); //LLamada al evento para comprobar el valor de difer con currenthealth

            _currentHealth = value; //Iguala la cantidad de vida actual al valor que est� debe tener
            OnHealthChanged?.Invoke(_currentHealth); //LLamada al evento de cambio de vida

            if (value <= 0) Death(); //Si el valor de la vida es = o menor a 0 llamada al m�todo muerte
        }
    }
    public float maxHealth
    {
        get => _maxHealth;//Obtiene la vida m�xima
        set
        {
            OnMaxHealthChanged?.Invoke(_maxHealth); //LLamada al evento de cambio de vida m�xima
        }
    }

    void Start() => SetCurrentHealth(maxHealth); //Al inicio se setea la vida actual a la m�xima
    public void Death() => onDeath?.Invoke(); //LLamada al evento de muerte

    public void TakeDamage(float damage) //m�todo que se llama cada vez que se recive da�o
    {
        currentHealth -= damage; // Cambia la vida actual en funci�n del da�o que recive
        if(currentHealth > 0) OnTakeDamage?.Invoke(); //Llamada al evento de recivir da�o siempre y cuando la vida sea > 0
        LookLowLife(); //Llamada al m�todo para comprobar la vida del jugador
    }

    public void NecroDamage(float damage) //m�todo que se llama cuando el necronomicon da�a al jugador
    {
        currentHealth -= damage; //Cambia la vida actual en funci�n del da�o que recive
        LookLowLife(); //Llamada al m�todo para comprobar la vida del jugador
    }

    public void Heal(float healAmount) //M�todo para curarse
    {
        if (healAmount > _maxHealth - currentHealth) //Si la cantidad de vida es mayor que la vida m�xima - la actual
        {
            currentHealth += _maxHealth - currentHealth; //La vida actual ser� la vida actual + la m�xima - la actual
        }
        else currentHealth += healAmount; //Si no la vida actual es la actual + la cantidad curada
        LookLowLife(); //Llamada al m�todo para comprobar la vida del jugador
    }
    public void SetMaxHealth(float newMaxHealth) //Setea la vida m�xima 
    {
        //Se setean ambas variables de maxhealth a la nueva vida m�xima
        _maxHealth = newMaxHealth;
        maxHealth = newMaxHealth;
    }
   
    public void SetCurrentHealth(float newCurrentHealth) => currentHealth = newCurrentHealth; //Setea la vida actual 
    public float GetCurrentHealth() => currentHealth; //Obtiene la vida actual 
    public float GetMaxHealth() => _maxHealth; //Obtiene la vida m�xima 
    private void LookLowLife() //M�todo que observa la vida del jugador y comprueba si est� en estado grave o no
    {
        if (currentHealth <= 4 && currentHealth > 0) //Si entra en estado cr�tico
        {
            if (!active) //Si no se encuentra activa ya
            {
                onLowLife?.Invoke(); //Llamada al evento de vida baja
                active = true; //Se cambia el valor del booleano
            }
        }
        else if (active) //Si est� activa y no tiene la vida baja
        {
            onNormalLife?.Invoke(); //Llamada al evento de vida normal
            active = false; //Se cambia el valor del booleano
        }
    }
}