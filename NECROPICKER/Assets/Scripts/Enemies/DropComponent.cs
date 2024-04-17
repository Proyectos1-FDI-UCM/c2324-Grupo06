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
    }

    public void DropItemExclusive()
    {
        int numofitem=0;
        bool noInstanciate = true;
        int randomPercentage = Random.Range(0, 101);
        for (int i = 0; i < dropItems.Count; i++)
        {
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
                LaunchItem(obj);
            }
        }
    }

    void LaunchItem(GameObject item)
    {
        if(item.TryGetComponent(out IBehaviour behaviour))
        {
            behaviour.ExecuteBehaviour();
        }
    }
    public void DropToCero(int i)
    {
        dropChance[i] = 0;
    }
    //El código está genial, esto son solo algunas sugerencias para mejorar la legibilidad y mantenibilidad del código
    //buen trabajo David! :D
    //Si tienes alguna duda, no dudes en preguntarme
}

