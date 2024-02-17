using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DropComponent : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItems = new List<GameObject>();
    [SerializeField]List<int> dropRate = new List<int>();
    private Transform _transform;
  
    private void Start()
    {
        _transform = transform;
   //     foreach (GameObject item in dropItems) dropItems.Add(item);
   //     foreach (int rate in dropRate) dropRate.Add(rate);
    }
    public void DropItems()
    { int j = 990; 
        //Que es 990? Trata de usar nombres mas descriptivos. 
        //también pon la línea de código en una línea que no sea la de la llave
        int randomPercentage = UnityEngine.Random.Range(0, 101); //UnityEngine lo puedes omitir
        Debug.Log(randomPercentage);
        for (int i = 0; i < dropItems.Count; i++)
        {
            //de esta manera termina instanciando el objeto que menor droprate tenga en caso de tener mas objetos instanciados
            if (dropItems[i] != null&& randomPercentage < dropRate[i]) j=i; 
            //Por qué la comprobación de dropItems[i] != null?
            //Además esto no va a coger el objeto con menor dropRate, sino el último que cumpla la condición
        }
        if (j == 990) return; 
        //Vale, ya entiendo que es 990, no obstante podrías utilizar directamente una variable tipo GameObject para esto
        //Aquí podrías comprobar en vez de j==990, objectToInstantiate != null. Así también se ve bastante más claro el código
        Instantiate(dropItems[j], _transform.position, _transform.rotation);
    }
    //El código está genial, esto son solo algunas sugerencias para mejorar la legibilidad y mantenibilidad del código
    //buen trabajo David! :D
    //Si tienes alguna duda, no dudes en preguntarme
}

