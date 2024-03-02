using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChromaticAberration : MonoBehaviour
{
    [SerializeField] VolumeProfile volumeProfile;
    [SerializeField] float intensity = 1;

    public void PlayAberration(float duration) => StartCoroutine(ExecuteAberration(duration));
    IEnumerator ExecuteAberration(float duration)
    {
        volumeProfile.TryGet(out UnityEngine.Rendering.Universal.ChromaticAberration chromaticAberration);
        chromaticAberration.intensity.Override(intensity);
        yield return new WaitForSeconds(duration);
        chromaticAberration.intensity.Override(0);
    }

}
