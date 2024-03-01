using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : IMenu
{
    [SerializeField]int n_MainMenu = 0;
    [SerializeField]int n_1ºlevel = 0;
    public override void ActiveMenu()
    {
        base.ActiveMenu();
        Time.timeScale = 0;
    }

    public override void DeactiveMenu()
    {
        base.DeactiveMenu();
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(n_MainMenu);
    }
    public void RestartGame() 
    {
        SceneManager.LoadScene(n_1ºlevel);
    }
}