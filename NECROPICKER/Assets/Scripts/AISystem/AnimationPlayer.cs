using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }

    public void SetTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }
}
