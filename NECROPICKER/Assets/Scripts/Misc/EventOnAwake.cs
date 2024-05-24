using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAwake : MonoBehaviour
{
    [SerializeField] UnityEvent onAwake = new UnityEvent();
    public UnityEvent OnAwake => onAwake;
  /// <summary>
  /// Invoca el evento asignado desde el editor en el awake
  /// </summary>
    private void Awake()
    {
        onAwake?.Invoke();
    }
}
