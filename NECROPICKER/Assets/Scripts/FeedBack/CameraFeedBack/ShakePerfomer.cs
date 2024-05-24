using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TriggerArea))]
[RequireComponent(typeof(CinemachineVirtualCamera))]
public class ShakePerfomer : MonoBehaviour
{
    [SerializeField] CameraEffects cameraEffects;
    TriggerArea triggerArea;
    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    [SerializeField] float shakeTime = 0.20f;
    //Toma los componentes necesarios y se suscribe a eventos
    private void Awake()
    {
        triggerArea = GetComponent<TriggerArea>();

        cinemachineBasicMultiChannelPerlin = 
        GetComponent<CinemachineVirtualCamera>().
        GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        triggerArea.onTriggerEnter.AddListener(SubscribeToCameraEffects);
        triggerArea.onTriggerExit.AddListener(UnsubscribeToCameraEffects);
    }
    //Se suscribe al evento ShakeEvent de camera effects
    void SubscribeToCameraEffects() => cameraEffects.ShakeEvent.AddListener(Shake);
    //Se desuscribe al evento ShakeEvent de camera effects
    void UnsubscribeToCameraEffects() => cameraEffects.ShakeEvent.RemoveListener(Shake);
    //Inicia una corrutina
    void Shake(float shakeValue) => StartCoroutine(ShakeRoutine(shakeValue));
    //CinemachineMultiChannelPerlin aplica ruidos perlin a la cámara, básicamente, se controla la intensidad y la frecuencia de sacudida de la cámara con el parámetro shake value, se espera shakeTime segundos y se reestablece a los valores originales (0)
    IEnumerator ShakeRoutine(float shakeValue)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeValue;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = shakeValue;
        //Gamepad.current.SetMotorSpeeds(3f, 3f);

        yield return new WaitForSecondsRealtime(shakeTime);

        //Gamepad.current.SetMotorSpeeds(0, 0);
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0;
    }
        
}
