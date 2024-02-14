using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    [SerializeField] Transform _target;
    public Transform target => _target;

    private void Awake() {
        if(_target == null)
            _target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
