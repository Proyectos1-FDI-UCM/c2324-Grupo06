using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInTime : MonoBehaviour
{
    [SerializeField] float duration = 10;
    [SerializeField] float fadeStartPoint = 4;
    float timer;
    SpriteRenderer[] spriteRenderers;

    private void Awake() {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update() 
    {
        timer -= Time.deltaTime;

        if(timer <= fadeStartPoint)
        {
            foreach(SpriteRenderer sr in spriteRenderers)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, timer / fadeStartPoint);
            }
        } 
    }

    private void OnEnable() 
    {
        foreach(SpriteRenderer sr in spriteRenderers)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
        }

        timer = duration;
    }
}
