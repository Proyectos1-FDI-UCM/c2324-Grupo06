using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotationBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private Transform _ParentTransform;
   
    private void Awake()
    {
        _ParentTransform = GetComponentInParent<Transform>();
    }
    public void ExecuteBehaviour()
    {
        _ParentTransform.Rotate(0,0,45);
    }

}