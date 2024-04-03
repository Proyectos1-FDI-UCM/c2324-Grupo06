using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades", order = 1)]
public class Upgrades : ScriptableObject
{// primera estadistica vida seguida de numero maximo de pociones y velocidad de movimiento
    [SerializeField] private float[] stats = new float[3];
    [SerializeField] GameObject player;
    
    public void SetStats()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<HealthHandler>().SetMaxHealth(stats[0]);
        //falta potis
        player.GetComponent<MovementController>().SetSpeed(stats[2]);
    }
    public void Resetstats()
    {
        player.GetComponent<HealthHandler>().SetMaxHealth(12);
        //falta potis
        player.GetComponent<MovementController>().SetSpeed(15f);

    }
    public void AddSpeed(float aumento)
    {
        stats[2] += aumento;
        SetStats();
    }
}
