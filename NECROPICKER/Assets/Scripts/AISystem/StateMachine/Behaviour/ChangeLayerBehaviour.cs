using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChangeDistanceItem : MonoBehaviour, IBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] LayerMask targetLayer;
    public void ExecuteBehaviour()
    {
        item.layer = targetLayer;
    }
}
