using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnColisiion : MonoBehaviour, ICollidable
{
    // Start is called before the first frame update
    [SerializeField] float minSpeed = 2;
    Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip collisionAnimation;
    [SerializeField] LayerMask targetLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void OnCollide(Collider2D other)
    {
        if (rb.velocity.magnitude >= minSpeed && targetLayer == (targetLayer | (1 << other.gameObject.layer))) StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        animator.Play(collisionAnimation.name);
        rb.isKinematic = true;
        yield return new WaitForSeconds(collisionAnimation.length);
        Destroy(gameObject);
    }
}
