using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceOnDestroy : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Texture2D texture;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        texture = spriteRenderer.sprite.texture;
        Slice();
    }

    private void Slice() {
        Texture2D newTexture = new Texture2D(texture.width, texture.height);
        newTexture.SetPixels(texture.GetPixels());
        newTexture.Apply();
        spriteRenderer.sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f));
    }
}
