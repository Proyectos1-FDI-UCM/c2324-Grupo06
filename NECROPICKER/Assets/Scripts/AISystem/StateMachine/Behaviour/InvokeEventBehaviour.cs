using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Este comportamiento se utiliza para ejecutar eventos de Unity en el editor de Unity.
public class InvokeEventBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] UnityEvent OnExecuteBehaviour;
    public void ExecuteBehaviour() => OnExecuteBehaviour?.Invoke();
}
