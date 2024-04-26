using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsatanceOnTrigger : MonoBehaviour
{
    [SerializeField] GameObject enemy;
     [SerializeField] GameObject player;
    
    
    
       
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Instantiate(enemy);
    }
}
