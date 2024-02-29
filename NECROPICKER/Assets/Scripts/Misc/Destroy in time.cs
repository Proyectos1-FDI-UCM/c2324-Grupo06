using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Destroyintime : MonoBehaviour
{
    [SerializeField] float destroytime = 1.0f;
    [SerializeField] GameObject GameObject;
    void Start()
    {
        Destroy(GameObject, destroytime);
    }
}
