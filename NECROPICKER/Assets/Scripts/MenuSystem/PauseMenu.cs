using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : IMenu
{
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
}