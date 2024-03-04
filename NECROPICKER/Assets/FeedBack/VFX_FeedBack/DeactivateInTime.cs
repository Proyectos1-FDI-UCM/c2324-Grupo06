using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInTime : MonoBehaviour
{
    [SerializeField] float deactivateTime = 1.0f;
    
    private void OnEnable() {
        StartCoroutine(Deactivate());
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(deactivateTime);
        gameObject.SetActive(false);
    }
}
