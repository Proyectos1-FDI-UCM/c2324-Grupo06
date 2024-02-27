using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairComponent : MonoBehaviour
{
    [SerializeField] int numeroescena = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != GetComponent<InputManager>())
        {
            SceneManager.LoadScene(numeroescena);
        }

    }
}
