using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSizeBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] Vector3 sizeDifference;
    [SerializeField] GameObject targetObject;
    public void ExecuteBehaviour()
    {
        targetObject.transform.localScale += sizeDifference;
    }
    private void OnValidate()
    {
        name = "Change object size";
    }
}
