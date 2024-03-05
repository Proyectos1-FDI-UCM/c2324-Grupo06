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

    private void Awake()
    {
        triggerArea = GetComponent<TriggerArea>();

        cinemachineBasicMultiChannelPerlin = 
        GetComponent<CinemachineVirtualCamera>().
        GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        triggerArea.onTriggerEnter.AddListener(SubscribeToCameraEffects);
        triggerArea.onTriggerExit.AddListener(UnsubscribeToCameraEffects);
    }

    void SubscribeToCameraEffects() => cameraEffects.ShakeEvent.AddListener(Shake);
    void UnsubscribeToCameraEffects() => cameraEffects.ShakeEvent.RemoveListener(Shake);

    void Shake(float shakeValue) => StartCoroutine(ShakeRoutine(shakeValue));

    IEnumerator ShakeRoutine(float shakeValue)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeValue;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = shakeValue;
        print(Gamepad.current.name);
        Gamepad.current.SetMotorSpeeds(3f, 3f);

        yield return new WaitForSecondsRealtime(shakeTime);

        Gamepad.current.SetMotorSpeeds(0, 0);
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0;
    }
        
}
