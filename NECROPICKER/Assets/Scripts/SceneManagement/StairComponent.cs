using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairComponent : MonoBehaviour
{
    [SerializeField] string sceneName;
    //Si el objeto que entra en la zona del trigger contiene el animator de Jefferson, se carga la siguiente escena
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != GetComponent<AnimationComponentJefferson>())
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
