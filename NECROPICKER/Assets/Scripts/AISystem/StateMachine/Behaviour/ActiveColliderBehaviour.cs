using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColliderBehaviour : MonoBehaviour , IBehaviour
{
    public bool active = false;
    private Collider2D _collider;
    private void Awake()
    {
        _collider = GetComponentInParent<Collider2D>();
    }
    public void ExecuteBehaviour()
    {
        _collider.enabled = active;
    }

    private void OnValidate()
    {
            name = "Active Collider2D"+ active;
    }
}
