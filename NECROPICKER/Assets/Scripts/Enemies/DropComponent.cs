using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public void DropItemExclusive()
    {
        int numofitem=0;
        bool noInstanciate = true;
        int randomPercentage = UnityEngine.Random.Range(0, 101); 
       // Debug.Log(randomPercentage);
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

    public void DropItem()
    {
        int randomPercentage = Random.Range(0, 101);
        for (int i = 0; i < dropItems.Count; i++)
        {
            if (randomPercentage < dropChance[i])
            {
                GameObject obj = Instantiate(dropItems[i], _transform.position, _transform.rotation);
                if(obj.TryGetComponent(out Rigidbody2D rb))
                {
                    int RandomNum = Random.Range(0, 360);
                    rb.velocity = new Vector2(Mathf.Sin(RandomNum), Mathf.Cos(RandomNum) * Random.Range(15f, 20f));
                }
            }
        }
    }
    //El código está genial, esto son solo algunas sugerencias para mejorar la legibilidad y mantenibilidad del código
    //buen trabajo David! :D
    //Si tienes alguna duda, no dudes en preguntarme
}

