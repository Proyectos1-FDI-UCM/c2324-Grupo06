using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class InmuneComponent : MonoBehaviour
{
    HealthHandler healthHandler;
    
    [SerializeField] private float _cont = 1.5f;
    void Start()
    {
        healthHandler = GetComponent<HealthHandler>();
    }

    public void OnTakeDamage()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer() 
    {                                                  //primero hace esto
        healthHandler.SetInmune(true);
        yield return new WaitForSecondsRealtime(_cont);// luego se espera
        healthHandler.SetInmune(false);                //y finalmente hace esto
    }
}
