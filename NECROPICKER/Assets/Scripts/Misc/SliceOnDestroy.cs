using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceOnDestroy : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Texture2D texture;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
