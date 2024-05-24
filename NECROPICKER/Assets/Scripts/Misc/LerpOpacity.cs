using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpOpacity : MonoBehaviour
{

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float time;
    [SerializeField] bool fadeOut;
    private float passedtime;
    //permite cambiar la opacidad de un objeto ya sea aumentandola de 0 a 1 o viceversa
    void Update()
    {
        passedtime += Time.deltaTime;
        float t = Mathf.Clamp01(passedtime/ time);

         if (fadeOut)sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(1f, 0f, t));
        
         else sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(1f, 0f, t));
    }


}
