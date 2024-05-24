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
    [SerializeField] private Upgrades upgrades;
    [SerializeField] private InputActionReference inputActionReference;
    bool enArea;
    //si hay un jugador en el area permite cambiar de escena al pulsar el input elegido. Ademas guarda la vida actual del player
    //entre escenas
    private void Update()
    {
        if (enArea)
        {
            if (inputActionReference.action.WasPerformedThisFrame())
            {
                upgrades.StorageActHealth(upgrades.FindPlayer().GetComponent<HealthHandler>().GetCurrentHealth());
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
