using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    [SerializeField] Vector2 rotationRange = new Vector2(-180, 180);
    private void OnEnable() 
    {
        StartCoroutine(waitAndRandomizeRotation());
    }

    IEnumerator waitAndRandomizeRotation()
    {
        yield return new WaitForEndOfFrame();
        RandomizeRotation();
    }

     public void RandomizeRotation() 
    {
        transform.rotation = Quaternion.identity;
        transform.Rotate(0, 0, Random.Range(rotationRange.x, rotationRange.y));
    }
}
