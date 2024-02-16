using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomChildren : MonoBehaviour
{
    UnityEvent<GameObject[]> OnChildrenDisplayed = new UnityEvent<GameObject[]>();

    [SerializeField] float[] percentages;

    private void Start()
    {
        List<GameObject> children = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            bool shouldShow = Random.Range(0, 100) <= percentages[i];
            if(shouldShow)
            {
                children.Add(transform.GetChild(i).gameObject);
            }
            else Destroy(transform.GetChild(i).gameObject);
        }

        OnChildrenDisplayed?.Invoke(children.ToArray());
    }
    private void OnValidate()
    {
        //Hacer aquí la copia del array de porcentajes, asignar el nuevo array con el tamaño del número de hijos
        //y luego copiar los valores del array antiguo al nuevo.
        percentages = new float[transform.childCount];
    }
}
