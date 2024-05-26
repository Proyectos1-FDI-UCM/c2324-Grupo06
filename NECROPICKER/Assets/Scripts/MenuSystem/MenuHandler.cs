using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script maneja las transiciones de menú basadas en los cambios de estado del juego.
// Escucha varios eventos (Pausa, Reanudar, Muerte, Cargando, Minimapa) del GlobalStateManager 
// y actualiza el menú activo en consecuencia.

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GlobalStateManager globalStateManager;

    private void Awake()
    {
        globalStateManager.OnPause.AddListener(() => ChangeMenu(MenuType.Pause));
        globalStateManager.OnResume.AddListener(() => ChangeMenu(MenuType.none));
        globalStateManager.OnDeath.AddListener(() => ChangeMenu(MenuType.Death));
        globalStateManager.OnLoading.AddListener(() => ChangeMenu(MenuType.Loading));
        globalStateManager.OnMinimap.AddListener(() => ChangeMenu(MenuType.Minimap));
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
    Pause,
    Death,
    Loading,
    Minimap
}