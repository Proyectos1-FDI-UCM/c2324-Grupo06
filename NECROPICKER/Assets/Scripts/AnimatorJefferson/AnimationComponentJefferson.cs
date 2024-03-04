using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponentJefferson : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    Rigidbody2D rb;
    float previousX;
    float previousY;
    bool isMooving;

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
