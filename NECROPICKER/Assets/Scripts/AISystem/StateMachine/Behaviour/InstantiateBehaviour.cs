using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditorInternal;
using UnityEngine;

public class InstantiateBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float velocity = 0.0f;
    [SerializeField] bool setAnimationOn;
    public void ExecuteBehaviour()
    {
        GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
        if (velocity != 0)
        {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * velocity;
        }
        if (setAnimationOn)
        {
            bullet.AddComponent<Animator>();
        }
    }

    private void OnValidate()
    {
        if(prefab != null)
            name = $"Instantiate {prefab.name}";
    }
}