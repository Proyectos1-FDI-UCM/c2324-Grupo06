using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnColisiion : MonoBehaviour, ICollidable
{
    // Start is called before the first frame update
    [SerializeField] float minSpeed = 2;
    Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] float tiempoAnim = 0.3f;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] private GameObject prefab;

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
        Debug.Log("Hola");
        animator.Play("Explosion");
        yield return new WaitForSeconds(tiempoAnim);
        Destroy(prefab);
    }
}
