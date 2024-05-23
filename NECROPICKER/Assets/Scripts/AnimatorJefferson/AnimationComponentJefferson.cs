using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponentJefferson : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    float previousX;
    float previousY;
    bool isMooving;
    //Tomando en cuenta el vector de la velocidad del rigid body, determina si se está moviendo o no y posteriormente determina en qué dirección está moviendose a partir de ese mismo vector
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x == 0f && rb.velocity.y == 0f)
        {
            isMooving = false;
        }
        else
        {
            isMooving = true;
        }
        animator.SetBool("IsMooving", isMooving);
        if (isMooving != false)
        {
            previousX = rb.velocity.x;
            previousY = rb.velocity.y;
        }

        animator.SetFloat("xDirection", previousX);
        animator.SetFloat("yDirection", previousY);
    }
}
