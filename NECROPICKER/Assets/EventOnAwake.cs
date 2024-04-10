using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAwake : MonoBehaviour
{
    [SerializeField] UnityEvent onAwake = new UnityEvent();
    public UnityEvent OnAwake => onAwake;

    private void Awake()
    {
        onAwake?.Invoke();
    }
}
