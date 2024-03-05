using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GlobalStateManager globalStateManager;

    private void Awake()
    {
        globalStateManager.OnPause.AddListener(() => ChangeMenu(MenuType.Pause));
        globalStateManager.OnResume.AddListener(() => ChangeMenu(MenuType.none));
    }

    void ChangeMenu(MenuType menuType)
    {
        foreach (Menu menu in GetComponentsInChildren<Menu>(true))
        {
            menu.gameObject.SetActive(menu.MenuType == menuType);
        }
    }
}

public enum MenuType
{
    none,
    Pause
}