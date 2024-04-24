using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHealing : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    ParticleSystem _healingparticles;
    public bool Use(ItemHandler handler)
    {
        GetComponent<ParticleSystem>().Play(_healingparticles);
        return true;
    }
}
