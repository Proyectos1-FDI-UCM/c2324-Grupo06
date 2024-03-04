using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour, ICollidable
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] AnimationClip collisionAnimation;
    [SerializeField] LayerMask targetLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void OnCollide(Collider2D other)
    {
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer))) StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        animator.Play(collisionAnimation.name);
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(collisionAnimation.length);
        Destroy(gameObject);
    }
}
