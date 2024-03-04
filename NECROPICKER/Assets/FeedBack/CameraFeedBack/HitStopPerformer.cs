using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStopPerformer : MonoBehaviour
{
    [SerializeField] CameraEffects cameraEffects;

    private void Awake()
    {
        cameraEffects.OnHitStop.AddListener(HitStopMethod);
    }

    private void OnDestroy() {
        cameraEffects.OnHitStop.RemoveListener(HitStopMethod);
    }

    void HitStopMethod(float hitStopValue)
    {
        StartCoroutine(HitStop(hitStopValue));
    }

    IEnumerator HitStop(float hitStopValue)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(hitStopValue);
        Time.timeScale = 1;
    }
}
