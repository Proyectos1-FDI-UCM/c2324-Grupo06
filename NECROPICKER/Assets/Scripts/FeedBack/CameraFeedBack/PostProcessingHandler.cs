using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingHandler : MonoBehaviour
{
    [SerializeField] VolumeProfile volumeProfile;
    [SerializeField] float intensity = 1;
    //Inicia una corrutina
    public void PlayAberration(float duration) => StartCoroutine(ExecuteAberration(duration));
    //Toma el efecto de aberración cromática del Volume, establece la intensidad al valor de intensity, espera duration segundos y lo establece a cero (deja de verse)
    IEnumerator ExecuteAberration(float duration)
    {
        volumeProfile.TryGet(out UnityEngine.Rendering.Universal.ChromaticAberration chromaticAberration);
        chromaticAberration.intensity.Override(intensity);
        yield return new WaitForSeconds(duration);
        chromaticAberration.intensity.Override(0);
    }
    //Inicia una corrutina
    public void PlayFilmGrain(float duration) => StartCoroutine(ExecuteFilmGrain(duration));
    //Activa el granulado de película durante duración segundos y luego lo desactiva
    IEnumerator ExecuteFilmGrain(float duration)
    {
        volumeProfile.TryGet(out UnityEngine.Rendering.Universal.FilmGrain filmGrain);
        filmGrain.active = true;
        yield return new WaitForSeconds(duration);
        filmGrain.active = false;
    }
    //Inicia una corrutina
    public void PlayColorAdjustments(float duration) => StartCoroutine(ExecuteColorAdjustments(duration));
    //Activa el ajuste de colores durante duration segundos y luego lo desactiva
    IEnumerator ExecuteColorAdjustments(float duration)
    {
        volumeProfile.TryGet(out UnityEngine.Rendering.Universal.ColorAdjustments colorAdjustments);
        colorAdjustments.active = true;
        yield return new WaitForSeconds(duration);
        colorAdjustments.active = false;
    }
    //Llaman al método reset
    private void OnDestroy() => Reset();

    private void Awake() => Reset();
    //establece todoslos efectos del volume para que no sean visibles
    private void Reset()
    {
        volumeProfile.TryGet(out UnityEngine.Rendering.Universal.ChromaticAberration chromaticAberration);
        chromaticAberration.intensity.Override(0);
        volumeProfile.TryGet(out UnityEngine.Rendering.Universal.FilmGrain filmGrain);
        filmGrain.active = false;
        volumeProfile.TryGet(out UnityEngine.Rendering.Universal.ColorAdjustments colorAdjustments);
        colorAdjustments.active = false;
    }
}
