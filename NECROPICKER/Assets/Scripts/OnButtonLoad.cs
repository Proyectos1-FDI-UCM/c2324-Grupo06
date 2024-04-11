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
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("A");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
}
