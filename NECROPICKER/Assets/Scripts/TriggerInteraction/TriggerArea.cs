using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour //Método encargado de instanciar los distintos objetos en sala
{
    [field: SerializeField]
    public UnityEvent onTriggerEnter { get; private set; } //Evento que se llama cuando se entra en el trigger

    [field: SerializeField]
    public UnityEvent onTriggerExit { get; private set; } //Evento que se llama cuando sale del trigger

    [SerializeField] LayerMask triggerLayer; //Referencia a la capa a detectar

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(triggerLayer == (triggerLayer | (1 << other.gameObject.layer))) //Si la capa seleccionada coincide con la capa del Collider
            onTriggerEnter.Invoke(); //Llamada al evento de entrada
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(triggerLayer == (triggerLayer | (1 << other.gameObject.layer))) //Si la capa seleccionada coincide con la capa del Collider
            onTriggerExit.Invoke(); //Llamada al evento de salida
    }
}
