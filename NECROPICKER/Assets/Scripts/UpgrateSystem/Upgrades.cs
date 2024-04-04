using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades", order = 1)]
public class Upgrades : ScriptableObject
{// primera estadistica vida seguida de numero maximo de pociones y velocidad de movimiento
    [SerializeField] private float[] stats = new float[3];
     GameObject player;
    [SerializeField] private float Ini_maxhealth = 0;
    [SerializeField] private float Ini_speed = 0;
    
    public void SetStats()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<HealthHandler>().SetMaxHealth(stats[0]);
        player.GetComponent<HealthHandler>().Heal(10000);
        //falta potis
        player.GetComponent<MovementController>().SetSpeed(stats[2]);
    }
    public void Resetstats()
    {
        stats[0] = Ini_maxhealth;
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
        stats[0] += aumento;
        SetStats();
    }
}
