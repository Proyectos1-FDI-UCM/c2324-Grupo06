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
            bool shouldShow = Random.Range(0, 100) <= percentages[i]; //"None" forma parte de la lista de gameobjects que pueden aparecer, si seteas un 100% de probabilidades de aparecer y no salen todos los enemigos es que se ha seleccionado None, hay que cambiarlo desde el scriptable object de enemigos e items
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
        float[] copy = Copy(percentages);
        percentages = new float[transform.childCount];
        for(int i = 0; i < copy.Length; i++)
        {
            percentages[i] = copy[i];
        }
    }
    private float[] Copy(float[] array)
    {
        float[] copy = new float[array.Length];
        for(int i = 0; i < array.Length; i++)
        {
            copy[i] = array[i];
        }
        return copy;
    }
}
