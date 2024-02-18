using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DropComponent : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItems = new List<GameObject>();
    [SerializeField]List<int> dropChance = new List<int>();
    private Transform _transform;
  
    private void Start()
    {
        _transform = transform;
   //     foreach (GameObject item in dropItems) dropItems.Add(item);
   //     foreach (int rate in dropChance) dropRate.Add(rate);
    }
    public void DropItems()
    {
        int numofitem=0;
        bool noInstanciate = true;
        int randomPercentage = UnityEngine.Random.Range(0, 101); 
        Debug.Log(randomPercentage);
        for (int i = 0; i < dropItems.Count; i++)
        {
            //de esta manera termina instanciando el objeto que menor droprate tenga en caso de tener mas objetos instanciados
            if (randomPercentage < dropChance[i] && dropChance[i] <= dropChance[numofitem])
            {
                numofitem = i;
                noInstanciate = false;
            }
        }
        if (!noInstanciate)Instantiate(dropItems[numofitem], _transform.position, _transform.rotation);
    }
    //El código está genial, esto son solo algunas sugerencias para mejorar la legibilidad y mantenibilidad del código
    //buen trabajo David! :D
    //Si tienes alguna duda, no dudes en preguntarme
}

