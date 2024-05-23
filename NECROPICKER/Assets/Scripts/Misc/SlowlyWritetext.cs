using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class SlowlyWritetext : MonoBehaviour
{
    /// <summary>
    /// necesita un textmeshpro y el string a escribir
    /// escribe el texto del string letra a letra en funcion a la velocidad writingSpeed
    /// </summary>
    public float writingSpeed = 0.1f; // Velocidad de escritura en segundos
    public TextMeshPro textUI;
    public string texct;
    [SerializeField] UnityEvent OnCharWrite = new UnityEvent();
    void Start()
    {
        StartCoroutine(SlowlWriting());
    }

    IEnumerator SlowlWriting()
    {
        foreach (char letra in texct)
        {
            textUI.text += letra;
            OnCharWrite.Invoke();
            yield return new WaitForSeconds(writingSpeed*Time.deltaTime);
        }
    }
}
