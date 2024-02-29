using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMenu : MonoBehaviour
{
    [SerializeField] MenuType menuType;
    public MenuType MenuType => menuType;
    public virtual void ActiveMenu() => gameObject.SetActive(true);
    public virtual void DeactiveMenu() => gameObject.SetActive(false);
}

public enum MenuType
{
    Pause,
    GameOver
}
