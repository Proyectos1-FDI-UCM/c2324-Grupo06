using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    Singleton _instance;
    public static Singleton Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            Destroy(this);
        }
    }
}
