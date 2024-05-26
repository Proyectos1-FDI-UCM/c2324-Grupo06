using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Tipo de menú que se asignará a este script
    [SerializeField] MenuType menuType;

    // Tipo de menú que se asignará a este script
    public MenuType MenuType => menuType;
}
