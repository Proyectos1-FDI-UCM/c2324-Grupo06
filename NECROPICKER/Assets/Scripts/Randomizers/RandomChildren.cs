using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomChildren : MonoBehaviour //Método que setea una cantidad definida de gameObjects en función de unos porccentajes (Decide la cantidad de enemigos que aparecen por sala)
{
    UnityEvent<GameObject[]> OnChildrenDisplayed = new UnityEvent<GameObject[]>(); //Evento de lista de gameobjects

    [SerializeField] float[] percentages; //Array de porcentajes

    private void Start()
    {
        List<GameObject> children = new List<GameObject>(); //Se inicializa la lista

        for (int i = 0; i < transform.childCount; i++) //Se recorre para cada hijo
        {
            bool shouldShow = Random.Range(0, 100) <= percentages[i]; //"None" forma parte de la lista de gameobjects que pueden aparecer, si seteas un 100% de probabilidades de aparecer y no salen todos los enemigos es que se ha seleccionado None, hay que cambiarlo desde el scriptable object de enemigos e items
            if(shouldShow)
            {
                children.Add(transform.GetChild(i).gameObject); //Añade a la sala el objeto a instanciar
            }
            else Destroy(transform.GetChild(i).gameObject); //Elimina de la sala el objeto
        }

        OnChildrenDisplayed?.Invoke(children.ToArray()); //Llamada al evento en cuestión
    }
    private void OnValidate()
    {
        float[] copy = Copy(percentages);  //Se crea una variable auxiliar copia que contiene los porcentajes
        percentages = new float[transform.childCount]; //Se inicializa el array de porcentajes con el tamaño de los hijos a recorrer
        for(int i = 0; i < copy.Length; i++) //Para cada porcentaje se iguala en el array de porcentajes
        {
            percentages[i] = copy[i];
        }
    }
    private float[] Copy(float[] array)
    {
        float[] copy = new float[array.Length]; //Creación de una variable auxiliar copia de tamaño del array que le pasamos
        for(int i = 0; i < array.Length; i++) //Para cada componente del array se iguala los valores de la variable copia a los del array que le pasamos
        {
            copy[i] = array[i];
        }
        return copy; //Devolvemos copy ya rellenada al completo
    }
}
