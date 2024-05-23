using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Crea un evento para que la musica se pueda reproducir al empezar
public class MusicStartSignal : MonoBehaviour
{
    [SerializeField] UnityEvent onStart = new UnityEvent();
    public UnityEvent OnStart => onStart;
    // Start is called before the first frame update
    void Start()
    {
        onStart?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
