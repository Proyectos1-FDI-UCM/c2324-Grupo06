using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHealing : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    ParticleSystem _healingparticles; // Componente de part�culas que se activa al usar el item
    
    // Al usar el item, se activan las part�culas de curaci�n
    public bool Use(ItemHandler handler)
    {
        GetComponent<ParticleSystem>().Play(_healingparticles);
        return true;
    }
}
