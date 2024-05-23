using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// tras pasar el tiempo indicado el objeto se destruye
/// (No hay necesidad de usar un time.deltatime ya que el propio metodo recibe segundos)
/// </summary>
public class Destroyintime : MonoBehaviour
{
    [SerializeField] float destroytime = 1.0f;
    [SerializeField] GameObject GameObject;
    void Start()
    {
        if(GameObject == null) GameObject = gameObject;
        Destroy(GameObject, destroytime);
    }
}
