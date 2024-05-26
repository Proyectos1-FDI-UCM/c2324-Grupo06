using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//Este script es un gestor global del estado del juego, manejado como un ScriptableObject.
//Define varios eventos relacionados con los estados del juego (pausa, reanudación, muerte, reinicio, carga, y minimapa)
//y métodos para invocar estos eventos y cambiar el estado del juego en consecuencia.

[CreateAssetMenu(fileName = "GlobalStateManager", menuName = "GlobalStateManager")]
public class GlobalStateManager : ScriptableObject
{
    // Eventos para los diferentes estados del juego

    [SerializeField] UnityEvent onPause = new UnityEvent();
    public UnityEvent OnPause => onPause;

    [SerializeField] UnityEvent onResume = new UnityEvent();
    public UnityEvent OnResume => onResume;

    [SerializeField] UnityEvent onDeath = new UnityEvent();
    public UnityEvent OnDeath => onDeath;

    [SerializeField] UnityEvent onRestart = new UnityEvent();
    public UnityEvent OnRestart => onRestart;
    [SerializeField] UnityEvent onLoading = new UnityEvent();
    public UnityEvent OnLoading => onLoading;

    [SerializeField] UnityEvent onMinimap = new UnityEvent();
    public UnityEvent OnMinimap => onMinimap;

    [SerializeField] ScenesManager scenesManager;

    // Pausa el juego, invoca el evento onPause y detiene el tiempo
    public void Pause()
    {
        onPause?.Invoke();
        Time.timeScale = 0;
    }

    // Reanuda el juego, reanuda el tiempo y invoca el evento onResume
    public void Resume()
    {
        Time.timeScale = 1;
        onResume?.Invoke();
    }

    // Alterna entre pausar y reanudar el juego
    public void SwitchPause()
    {
        if (Time.timeScale == 0)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    // Reinicia el juego, invoca el evento onRestart, carga la escena inicial y reanuda el juego
    public void Restart()
    {
        onRestart?.Invoke();
        scenesManager.LoadScene("Level1");
        Resume();
    }

    // Sale del juego
    public void Exit()
    {
        Application.Quit();
    }

    // Maneja el evento de muerte, invoca el evento onDeath
    public void Death()
    {
        onDeath?.Invoke();
    }

    // Maneja el evento de carga, invoca el evento onLoading
    public void Loading()
    {
        onLoading?.Invoke();
    }

    // Muestra el minimapa, detiene el tiempo e invoca el evento onMinimap
    public void Minimap()
    {
        Time.timeScale = 0;
        onMinimap?.Invoke();
    }

    // Establece la escala de tiempo del juego
    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
  