using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

    public void PlayAnimation(string animationName)
    {
        Debug.Log(animationName);
        _animator.Play(animationName);
    }

    public void SetTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }
}
