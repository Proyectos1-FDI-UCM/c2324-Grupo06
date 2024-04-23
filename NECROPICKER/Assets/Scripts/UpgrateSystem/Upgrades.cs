using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades", order = 1)]
public class Upgrades : ScriptableObject
{// primera estadistica vida seguida de numero maximo de pociones y velocidad de movimiento
    [SerializeField] private float[] stats = new float[3];
    [SerializeField] ItemData Pociones;
    [SerializeField] private float act_health;
    [SerializeField] private float Ini_maxhealth = 0;
    [SerializeField] private int Ini_maxpotionsize = 0;
    [SerializeField] private float Ini_speed = 0;
    
    public GameObject FindPlayer() => FindAnyObjectByType<InputManager>().gameObject;
    public void SetStats()
    {
        GameObject player = FindPlayer();
        player.GetComponent<HealthHandler>().SetMaxHealth(stats[0]);
       
        Pociones.SetMaxStackSize((int)stats[1]);
        player.GetComponent<MovementController>().SetSpeed(stats[2]);
    }
    public void SetActHealth()
    {
        GameObject player = FindPlayer();
        player.GetComponent<HealthHandler>().SetCurrentHealth(act_health);
    }
    public void StorageActHealth(float health) => act_health = health;
    public void Resetstats()
    {
        StorageActHealth(Ini_maxhealth);
        stats[0] = Ini_maxhealth;
        stats[1] = Ini_maxpotionsize;
        stats[2] = Ini_speed;
        SetStats();

    }
    public void AddSpeed(float aumento)
    {
        stats[2] += aumento;
        SetStats();
    }

    public void AddMaxHealth(float aumento)
    {
        GameObject player = FindPlayer();

        stats[0] += aumento;

        SetStats();

        player.GetComponent<HealthHandler>().Heal(10000);
    }
    public void AddMaxPotionSize(int aumento)
    {
        GameObject player = FindPlayer();
        stats[1] += aumento;
        SetStats();
    }
}
