using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitStopPerformer : MonoBehaviour
{
    [SerializeField] CameraEffects cameraEffects;
    //Suscribe la cámara a los diferentes efectos visuales
    private void Awake()
    {
        cameraEffects.OnHitStop.AddListener(HitStopMethod);
        cameraEffects.OnDramaticHitStop.AddListener((curve, duration) => StartCoroutine(DramaticHitStop(curve, duration)));
    }
    //Cuando se destruye, se desuscribe de los eventos
    private void OnDestroy() {
        cameraEffects.OnHitStop.RemoveListener(HitStopMethod);
        cameraEffects.OnDramaticHitStop.RemoveListener((curve, duration) => StartCoroutine(DramaticHitStop(curve, duration)));
    }
    //Cuando se llama, inicia una corrutina
    void HitStopMethod(float hitStopValue) => StartCoroutine(HitStop(hitStopValue));
    //Pausa el juego por hitStopValue segundos y vuelve a la normalidad
    IEnumerator HitStop(float hitStopValue)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(hitStopValue);
        Time.timeScale = 1;
    }
    //Pausa y luego despausa el juego de forma progresiva
    IEnumerator DramaticHitStop(AnimationCurve curve, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            Time.timeScale = curve.Evaluate(time / duration);
            time += 0.05f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
