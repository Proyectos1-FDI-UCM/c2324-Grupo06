using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent onTriggerEnter { get; private set; }

    [field: SerializeField]
    public UnityEvent onTriggerExit { get; private set; }

    [SerializeField] LayerMask triggerLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(triggerLayer == (triggerLayer | (1 << other.gameObject.layer)))
            onTriggerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(triggerLayer == (triggerLayer | (1 << other.gameObject.layer)))
            onTriggerExit.Invoke();
    }
}
