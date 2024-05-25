using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInTime : MonoBehaviour
{
    [SerializeField] float deactivateTime = 1.0f;
    //Inicia una corrutina cuando el script se activa
    private void OnEnable() {
        StartCoroutine(Deactivate());
    }
    //La corrutina espera los segundos introducidos en deactivateTime y posteriormente desactiva el gameObject
    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(deactivateTime);
        gameObject.SetActive(false);
    }
}
