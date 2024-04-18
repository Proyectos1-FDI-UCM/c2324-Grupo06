using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OnButtonLoad : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private ScenesManager scenesManager;
    [SerializeField] private string scene;
    [SerializeField] private InputActionReference inputActionReference;
    bool enArea;
    // Start is called before the first frame update
    private void Update()
    {
        if (enArea)
        {
            if (inputActionReference.action.WasPerformedThisFrame())
            {
                scenesManager.LoadScene(scene);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        enArea = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
        enArea = false;
    }
}
