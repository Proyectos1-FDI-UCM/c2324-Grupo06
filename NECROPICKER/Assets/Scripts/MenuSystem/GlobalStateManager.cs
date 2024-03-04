using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GlobalStateManager", menuName = "GlobalStateManager")]
public class GlobalStateManager : ScriptableObject
{
    UnityEvent onGameOver = new UnityEvent();
    public UnityEvent OnGameOver => onGameOver;

    UnityEvent onPause = new UnityEvent();
    public UnityEvent OnPause => onPause;

    UnityEvent onResume = new UnityEvent();
    public UnityEvent OnResume => onResume;

    public void GameOver()
    {
        onGameOver?.Invoke();
    }

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
}