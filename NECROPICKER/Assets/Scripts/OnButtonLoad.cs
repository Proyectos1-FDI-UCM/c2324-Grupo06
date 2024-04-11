using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonLoad : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private ScenesManager scenesManager;
    [SerializeField] private string scene;
    bool enArea;
    // Start is called before the first frame update
    private void Update()
    {
        if (enArea)
        {
            if (Input.GetKeyDown(KeyCode.X))
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
