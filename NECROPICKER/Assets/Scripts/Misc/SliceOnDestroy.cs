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
        var rect = new Rect(texture.width / 4, texture.height / 4, texture.width / 2, texture.height / 2);
        var sprite = Sprite.Create(texture, rect, Vector2.one * 0.5f);
        spriteRenderer.sprite = sprite;
    }
}
