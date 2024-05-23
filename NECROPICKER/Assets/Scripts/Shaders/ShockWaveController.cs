using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShockWaveController : MonoBehaviour
{
    [SerializeField] private float shockWaveTime = 0.75f;
    private Coroutine shockWaveCoroutine;
    private Material _material;
    // Cada vez que se inicia, se inicia una corrutina que hace que el círculo que se genera con el shader aumente en diámetro, dando una sensación de onda
    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CallShockWave();
        }
    }
    public void CallShockWave()
    {
        shockWaveCoroutine = StartCoroutine(ShockWaveAction(-0.1f, 1f));
    }
    // Update is called once per frame
    private IEnumerator ShockWaveAction(float startPos, float endPos)
    {
        _material.SetFloat("_WaveDistanceFromCenter", startPos);

        float lerpedAmount = 0f;
        float elapsedTime = 0f;
        
        while (elapsedTime < shockWaveTime)
        {
            elapsedTime += Time.deltaTime;

            lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / shockWaveTime));
            _material.SetFloat("_WaveDistanceFromCenter", lerpedAmount);
            yield return null;
        }
    }
}
