using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CameraEffects", menuName = "FeedBack/CameraEffects", order = 1)]
public class CameraEffects : ScriptableObject
{
    UnityEvent<float> shakeEvent = new UnityEvent<float>();
    public UnityEvent<float> ShakeEvent => shakeEvent;
    
    public void Shake(float shakeValue) => shakeEvent.Invoke(shakeValue);
}
