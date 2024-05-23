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
    //Determina qué objeto se deja caer, basado en las probabilidades definidas en la lista dropChance. Solo deja caer uno, por lo que si varios cumplen los requisitos, se dejará caer el último que los cumpla
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
    //Determina qué items se dejan caer, basado en las probabilidades definidas por la lista dropChance y llama a LaunchItem. En este caso, puede caer más de un Item
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
    //Si el objeto que se va a droppearse tiene algún comportamiento, lo ejecuta
    void LaunchItem(GameObject item)
    {
        if(item.TryGetComponent(out IBehaviour behaviour))
        {
            behaviour.ExecuteBehaviour();
        }
    }
    //Hace que las posibilidades de droppeo de un item i sean cero
    public void DropToCero(int i)
    {
        dropChance[i] = 0;
    }
}

