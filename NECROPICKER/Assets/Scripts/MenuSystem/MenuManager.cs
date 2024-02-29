using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UIManager", menuName = "UIManager")]
public class MenuManager : ScriptableObject
{
    UnityEvent<MenuType> OnActiveUI = new UnityEvent<MenuType>();
    public UnityEvent<MenuType> OnActiveUIEvent => OnActiveUI;

    UnityEvent<MenuType> OnUIDeactive = new UnityEvent<MenuType>();
    public UnityEvent<MenuType> OnUIDeactiveEvent => OnUIDeactive;

    public void ActiveMenu(MenuType MenuType) => OnActiveUI.Invoke(MenuType);
    public void DeactiveMenu(MenuType MenuType) => OnUIDeactive.Invoke(MenuType);
}