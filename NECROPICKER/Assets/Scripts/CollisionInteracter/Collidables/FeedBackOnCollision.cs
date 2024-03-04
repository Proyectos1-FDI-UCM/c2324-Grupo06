using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackOnCollision : MonoBehaviour, ICollidable
{
    [SerializeField] CameraEffects cameraEffects;
    [SerializeField] float hitStopValue = 0.1f;
    [SerializeField] float shakeValue = 0.1f;

    public void OnCollide(Collider2D collider)
    {
        cameraEffects.HitStop(hitStopValue);
        cameraEffects.Shake(shakeValue);
    }
}