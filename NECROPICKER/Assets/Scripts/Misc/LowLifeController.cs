using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowLifeController : MonoBehaviour
{
    public void PlayLowHealth(bool active) => StartCoroutine(LowLife(active));

    IEnumerator LowLife(bool active)
    {
        yield return null;
    }
}
