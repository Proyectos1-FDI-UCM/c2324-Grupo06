using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class SlowlyWritetext : MonoBehaviour
{
    public float writingSpeed = 0.1f; // Velocidad de escritura en segundos
    public TextMeshPro textUI;
    public string texct;
    [SerializeField] UnityEvent OnCharWrite = new UnityEvent();
    void Start()
    {
        StartCoroutine(EscribirTextoLentamente());
    }

    IEnumerator EscribirTextoLentamente()
    {
        foreach (char letra in texct)
        {
            textUI.text += letra;
            OnCharWrite.Invoke();
            yield return new WaitForSeconds(writingSpeed);
        }
    }
}
