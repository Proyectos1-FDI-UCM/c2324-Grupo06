using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Tipo de men� que se asignar� a este script
    [SerializeField] MenuType menuType;

    // Tipo de men� que se asignar� a este script
    public MenuType MenuType => menuType;
}
