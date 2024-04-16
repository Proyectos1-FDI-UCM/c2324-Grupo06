using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class FirstBotomSelector : MonoBehaviour
{
    [SerializeField] private GameObject bottom;
    private EventSystem eventSystem;
    // Start is called before the first frame update
    private void Start()
    {
        eventSystem = FindAnyObjectByType<EventSystem>();

        eventSystem.SetSelectedGameObject(bottom);
    }

    
}