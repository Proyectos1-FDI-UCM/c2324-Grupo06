using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuActivator : MonoBehaviour
{
    [SerializeField] MenuManager menuManager;
    IMenu[] menus;

    private void Awake() {
        menuManager.OnActiveUIEvent.AddListener(ActivateMenu);
        menuManager.OnUIDeactiveEvent.AddListener(DeactivateMenu);
        menus = GetComponentsInChildren<IMenu>(true);
    }

    void ActivateMenu(MenuType menuType) {
        foreach (var menu in menus) 
        {
            if (menu.MenuType == menuType) 
            {
                menu.ActiveMenu();
            }
        }
    }

    void DeactivateMenu(MenuType menuType) {
        foreach (var menu in menus) 
        {
            if (menu.MenuType == menuType) 
            {
                menu.DeactiveMenu();
            }
        }
    }
}