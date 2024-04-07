using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGraph : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out EnemyRegister _enemyRegister))
        {
            Debug.Log("Recogida");
        }
    }
}
