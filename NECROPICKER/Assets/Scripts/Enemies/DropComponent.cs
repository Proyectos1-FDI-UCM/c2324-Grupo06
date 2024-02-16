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
    { int j = 0;
        int randomPercentage = UnityEngine.Random.Range(0, 101);
        Debug.Log(randomPercentage);
        for (int i = 0; i < dropItems.Count; i++)
        {
            //de esta manera termina instanciando el objeto que menor droprate tenga en caso de tener mas objetos instanciados
            if (dropItems[i] != null&& randomPercentage < dropRate[i]) j=i;
        }
        Instantiate(dropItems[j], _transform.position, _transform.rotation);
    }
}

