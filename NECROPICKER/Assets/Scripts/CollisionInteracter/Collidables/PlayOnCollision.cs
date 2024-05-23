using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour, ICollidable
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] AnimationClip collisionAnimation; // Animación que se reproduce al colisionar
    [SerializeField] LayerMask targetLayer; // Capa con la que se debe colisionar

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void OnCollide(Collider2D other)
    {
        // Si la capa del objeto es la requerida, se llama a la corrutina Timer
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer))) StartCoroutine(Timer());
    }
    // Se reproduce la animación de colisión con el rigidbody kinemático y luego se destruye el objeto
    private IEnumerator Timer()
    {
        animator.Play(collisionAnimation.name);
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(collisionAnimation.length);
        Destroy(gameObject);
    }
}
