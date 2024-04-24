using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    [SerializeField] float healAmount = 10;

    [SerializeField] ParticleSystem _healingParticles;
    public bool Use(ItemHandler handler)
    {
       _healingParticles.Play();
        GetComponentInParent<HealthHandler>().Heal(healAmount);
        return true;
    }
}
