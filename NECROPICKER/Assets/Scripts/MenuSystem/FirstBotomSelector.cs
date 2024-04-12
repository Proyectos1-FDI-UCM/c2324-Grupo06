using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FirstBotomSelector : MonoBehaviour
{
    [SerializeField] private GameObject bottom;
    [SerializeField] private EventSystem eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem.firstSelectedGameObject = bottom;        
    }

    
}
