using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationCurveInfo", menuName = "FeedBack/AnimationCurveInfo", order = 1)]
//Scriptable object que define los par�metros de efecto de c�mara y curva de animaci�n junto con un m�todo p�blico PlayTimeModifier que llama al efecto de camara DramaticHitStop, estableciendo su duraci�n
public class TimeModifier : ScriptableObject
{
    [SerializeField] CameraEffects cameraEffects;
    [SerializeField] AnimationCurve curve;

    public void PlayTimeModifier(float duration) => cameraEffects.DramaticHitStop(curve, duration);
}
