using System.Collections;
using UnityEngine;
public class RotationBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private Transform _myTransform;

    [SerializeField] private float _rotationDegrees;
    [SerializeField] private float _rotationTime = 1;

    private void Awake()
    {
        if (_myTransform == null)
        {
            _myTransform = GetComponentInParent<Pointer>().transform;
        }
    }
    public void ExecuteBehaviour()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        float time = 0;
        float targetRotation = _myTransform.eulerAngles.z + _rotationDegrees;
        while (time < _rotationTime)
        {
            float rotation = Mathf.Lerp(_myTransform.eulerAngles.z, targetRotation, time / _rotationTime);
            _myTransform.rotation = Quaternion.Euler(0, 0, rotation);
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}