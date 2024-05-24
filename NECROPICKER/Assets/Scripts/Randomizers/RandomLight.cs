using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RandomLight : MonoBehaviour //Script que instancia luces en cierto rango que también se le pasa
{
    Light2D lightSpot;
    [SerializeField] Vector2 intensityRange = new Vector2(0.5f, 1.5f); //Valor de la intensidad
    [SerializeField] Vector2 radiusRange = new Vector2(1f, 3f); //Area del radio
    [SerializeField] Gradient colorGradient; //Gama de color 

    private void Awake() {
        lightSpot = GetComponent<Light2D>();
        lightSpot.intensity = Random.Range(intensityRange.x, intensityRange.y); //Se asigna la intensidad
        lightSpot.pointLightOuterRadius = Random.Range(radiusRange.x, radiusRange.y); //Se asigna el radio
        lightSpot.color = colorGradient.Evaluate(Random.Range(0f, 1f)); //Se asigna el color
    }
}
