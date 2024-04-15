using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "GlobalStateManager", menuName = "GlobalStateManager")]
public class GlobalStateManager : ScriptableObject
{
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


    public void Pause()
    {
        Time.timeScale = 0;
        onPause?.Invoke();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        onResume?.Invoke();
    }

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

    public void Restart()
    {
        onRestart?.Invoke();
        scenesManager.LoadScene("Level1");
        Resume();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Death()
    {
        onDeath?.Invoke();
    }

    public void Loading()
    {
        onLoading?.Invoke();
    }

    public void Minimap()
    {
        Time.timeScale = 0;
        onMinimap?.Invoke();
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
  