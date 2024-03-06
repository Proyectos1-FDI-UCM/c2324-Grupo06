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

    [SerializeField] InputActionAsset inputActionAsset;
    [SerializeField] ScenesManager scenesManager;


    public void Pause()
    {
        Time.timeScale = 0;
        inputActionAsset.Disable();

        onPause?.Invoke();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        inputActionAsset.Enable();
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
        scenesManager.ReloadScene();
        Resume();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Death()
    {
        Time.timeScale = 0;
        inputActionAsset.Disable();

        onDeath?.Invoke();
    }
}