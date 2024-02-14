using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildren : MonoBehaviour
{
    private void Start() {
        foreach (Transform child in transform) {
            bool shouldShow = Random.Range(0, 2) == 0;
            child.gameObject.SetActive(shouldShow);
        }
    }
}
