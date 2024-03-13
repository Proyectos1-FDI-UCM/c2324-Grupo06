using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairComponent : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != GetComponent<AnimationComponentJefferson>())
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
