using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnStart : MonoBehaviour
{
    [SerializeField] UnityEvent onStart = new UnityEvent();
    public UnityEvent OnStart => onStart;
    /// <summary>
    /// invoca el evento asignado en el editor en el start
    /// </summary>
    void Start()
    {
        onStart?.Invoke();
    }
}
