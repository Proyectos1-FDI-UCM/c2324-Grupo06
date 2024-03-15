using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveController : MonoBehaviour
{
    [SerializeField] private float shockWaveTime = 0.75f;
    private Coroutine shockWaveCoroutine;
    private Material _material;
    private static int _waveDistanceFromCenter = Shader.PropertyToID("WaveDistanceFromCenter");
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }
    public void CallShockWave()
    {
        ShockWaveAction(-0.1f, 0.1f);
    }

    // Update is called once per frame
    private IEnumerator ShockWaveAction(float startPos, float endPos)
    {
        _material.SetFloat(_waveDistanceFromCenter, startPos);

        float lerpedAmount = 0f;
        float elapsedTime = 0f;
        while(elapsedTime < shockWaveTime)
        {
            elapsedTime += Time.deltaTime;
            lerpedAmount = Mathf.Lerp(startPos, endPos, elapsedTime / shockWaveTime);
            _material.SetFloat(_waveDistanceFromCenter, lerpedAmount);
            yield return null;
        }
    }
}
