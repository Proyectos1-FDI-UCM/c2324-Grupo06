using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    [SerializeField] Vector2Int resolution = new Vector2Int(1000, 1000);
    private void Start() => SetResolutionMethod();

    void SetResolutionMethod() => Screen.SetResolution(resolution.x, resolution.y, true);
}
