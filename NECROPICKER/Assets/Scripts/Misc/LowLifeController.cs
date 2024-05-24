using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LowLifeController : MonoBehaviour
{
    [SerializeField] float duration = 3;
    [SerializeField] AnimationCurve curve;
    Vignette vignette;
    [SerializeField] VolumeProfile postProcessVolume;
    bool active = false;
    void Start() => postProcessVolume.TryGet(out vignette);
    public void PlayLowHealth(bool Active)
    {
        active = Active;
        StartCoroutine(LowLife());
    }
    // se encarga del efecto en pantalla cuando al player le queda poca vida
    IEnumerator LowLife()
    {
        float time = 0;
        if(!active)
        {
            vignette.intensity.Override(0);
            yield break;
        }
        while (active)
        {
            vignette.intensity.Override(curve.Evaluate(time / duration));
            time += 0.05f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}