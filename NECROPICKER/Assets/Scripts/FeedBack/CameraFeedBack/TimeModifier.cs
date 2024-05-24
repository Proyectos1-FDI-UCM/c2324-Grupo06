using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationCurveInfo", menuName = "FeedBack/AnimationCurveInfo", order = 1)]
//Scriptable object que define los parámetros de efecto de cámara y curva de animación junto con un método público PlayTimeModifier que llama al efecto de camara DramaticHitStop, estableciendo su duración
public class TimeModifier : ScriptableObject
{
    [SerializeField] CameraEffects cameraEffects;
    [SerializeField] AnimationCurve curve;

    public void PlayTimeModifier(float duration) => cameraEffects.DramaticHitStop(curve, duration);
}
