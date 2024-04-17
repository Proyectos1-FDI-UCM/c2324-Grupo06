using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RandomLight : MonoBehaviour
{
    Light2D lightSpot;
    [SerializeField] Vector2 intensityRange = new Vector2(0.5f, 1.5f);
    [SerializeField] Vector2 radiusRange = new Vector2(1f, 3f);
    [SerializeField] Gradient colorGradient;

    private void Awake() {
        lightSpot = GetComponent<Light2D>();

        lightSpot.intensity = Random.Range(intensityRange.x, intensityRange.y);
        lightSpot.pointLightOuterRadius = Random.Range(radiusRange.x, radiusRange.y);
        lightSpot.color = colorGradient.Evaluate(Random.Range(0f, 1f));
    }
}
