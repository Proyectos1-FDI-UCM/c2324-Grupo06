using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] CameraEffects cameraEffects; // Componente que se encarga de los efectos de la c�mara
    [SerializeField] float hitStopValue = 0.1f; // Valor que marca la duraci�n del hitstop
    [SerializeField] float shakeValue = 0.1f; // Valor que marca la intensidad del shake

    public void OnCollide(Collider2D collider)
    {
        // Se activan los efectos de la c�mara
        cameraEffects.HitStop(hitStopValue);
        cameraEffects.Shake(shakeValue);
    }
}